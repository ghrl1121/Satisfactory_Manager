//이건 참조용 입니다...
//공부가 필요해~
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
namespace FileUploader
{
    public partial class Form4 : Form
    {
        private Button button1;
        private DriveService service;
        public Form4()
        {
           //nitializeComponent();
        }
        private void btnAuth_Click(object sender, EventArgs e)
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,
                                DriveService.Scope.DriveFile,};
            var clientId = "*****.apps.googleusercontent.com";      //From https://console.developers.google.com
            var clientSecret = "******";          //From https://console.developers.google.com
            //여기에서 사용자에게 액세스 권한을 요청하거나 이전에 % AppData %에 저장된 새로 고침 토큰을 사용합니다.
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes,
            Environment.UserName, CancellationToken.None, new FileDataStore("UploaderToken")).Result;
            //동의를 받으면 토큰이 AppData 디렉터리에 로컬로 저장되므로 다음에 동의하라는 메시지가 표시되지 않습니다.
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "UploaderApp",
            });
            //파일 업로드와 같은 긴 작업은 시간 초과 될 수 있습니다. 100은 예방 적 값일 뿐이며 서비스를 사용하는 용도에 따라 합리적인 값으로 설정할 수 있습니다.
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            
            //세 번째 매개 변수가 비어 있으면 루트 디렉토리에 업로드한다는 의미입니다. 폴더 아래에 업로드하려면 여기에 폴더의 ID를 전달하십시오.
            var response = uploadFile(service, "" ,  "");
            MessageBox.Show("프로세스 완료 \n --- 응답 ---" + response);
            Console.WriteLine("Completed: " + response);
        }
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents= new List<string> { _parent };// 폴더에 업로드하려면 UN 주석 (위의 방법에서 상위 폴더의 ID를 매개 변수로 보내야 함)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, GetMimeType(_uploadFile));
                    request.SupportsTeamDrives= true;
                    // 진행 변경 이벤트 및 응답 수신 (완료된 이벤트)으로 이벤트 핸들러를 바인딩 할 수 있습니다.
                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;
                    request.UploadAsync();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("파일이 없습니다.", "404");
                return null;
            }
        }
        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        {
            //txtProgress.Text += obj.Status + " " + obj.BytesSent;
        }
        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
            if (obj != null)
            {
                Console.WriteLine("File was uploaded sucessfully--" + obj.Id);
                Console.WriteLine("Getting shareable link...");
                //완료되면 공유 가능한 링크를 받으세요:
                string fileId = obj.Id;
                Google.Apis.Drive.v3.Data.Permission permission = new Google.Apis.Drive.v3.Data.Permission();
                permission.Type = "anyone";
                permission.Role = "reader";
                permission.AllowFileDiscovery = true;
                PermissionsResource.CreateRequest request = service.Permissions.Create(permission, fileId);
                try
                {
                    request.Fields = "*";
                    request.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.Fields = "*";
                List<Google.Apis.Drive.v3.Data.File> files;
                Google.Apis.Drive.v3.Data.File myFile = null;
                try
                {
                    files = listRequest.Execute().Files.ToList();
                    myFile = files.Single(f => f.Id == fileId);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception2: " + e.Message);
                }
                string shareableLink = myFile.WebContentLink;
                Console.WriteLine("Shareable link to file: " + shareableLink);
            }
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Name = "Form4";
            this.ResumeLayout(false);

        }
    }
}
