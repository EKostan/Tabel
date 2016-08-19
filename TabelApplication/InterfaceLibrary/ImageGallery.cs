using System.Drawing;

namespace InterfaceLibrary
{
    public class ImageGallery
    {

        public static Image AddImage
        {
            get { return DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/add_16x16.png"); }
        }


        public static Image EditImage
        {
            get { return DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/edit/edit_16x16.png"); }
        }

        public static Image RemoveImage
        {
            get
            {
                return DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/removeitem_16x16.png");
            }

        }

        public static Image HistoryImage
        {
            get
            {
                return DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/history/historyitem_16x16.png");
            }
        }

        public static Icon HistoryIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/history/historyitem_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon PropertiesIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/setup/properties_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon PropertiesIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/setup/properties_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon TimeIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/scheduling/showworktimeonly_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }



        public static Icon TimeIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/scheduling/showworktimeonly_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon HistoryIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/history/historyitem_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon ContactIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/mail/contact_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }
        public static Icon ContactIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/mail/contact_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon ObjectIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/chart/steparea_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon ObjectIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/chart/steparea_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon JobIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/programming/ide_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon JobIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/programming/ide_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Image AddItemLargeImage
        {
            get
            {
                return DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/additem_32x32.png");
            }
        }


        public static Icon LockIcon
        {
            get { return Properties.Resources._lock; }
        }


        public static Icon TaskIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/tasks/task_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }
        public static Icon TaskIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/tasks/task_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon CopyIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/edit/copy_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AddFile
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/addfile_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon ReportIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/reports/report_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon ContentIcon
        {
            get
            {
                var image =
                    DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/miscellaneous/content_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RefreshIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/refresh_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RefreshIcon32
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/refresh_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon CloseIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/close_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon SavePageSetupIcon
        {
            get
            {
                var image =
                    DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/setup/savepagesetup_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SettingsIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/programming/ide_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon EmployeeIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/people/employee_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon PackageProductIcon
        {
            get
            {
                var image =
                    DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/packageproduct_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon TeamIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/people/team_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon MeetingIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("devav/view/meeting_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon MailLargeIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/mail/mail_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AddItemLargeIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/additem_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon FindLargeIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/find/find_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon FindIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/find/find_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon OpenIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/open_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon HelpIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/index_16x16.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }

        }

        public static Icon AddTaskToEmployeeIcon
        {
            get
            {
                var image = Properties.Resources.NewTaskEmployee_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AddGeneralTaskIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/tasks/newtask_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon DownloadIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/download_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon DownloadRawIcon
        {
            get
            {
                var image = Properties.Resources.DownloadRaw_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UploadIcon
        {
            get
            {
                var image = Properties.Resources.Upload_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UploadCustomerIcon
        {
            get
            {
                var image = Properties.Resources.UploadCustomer_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon CloneTaskIcon
        {
            get
            {
                var image = Properties.Resources.TaskClone_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon CancelTaskIcon
        {
            get
            {
                var image = Properties.Resources.CancelTask;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AssingTaskIcon
        {
            get
            {
                var image = Properties.Resources.TaskAssing_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AcceptTaskIcon
        {
            get
            {
                var image = Properties.Resources.AcceptTask_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon ConclusionIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/reports/report_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon NotConclusionIcon
        {
            get
            {
                var image = Properties.Resources.NotReport_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SendToArchiveIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/packageproduct_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SendToDBIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/database_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SendPrintIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/article_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UndoSendToArchiveIcon
        {
            get
            {
                var image = Properties.Resources.CancelPackageProduct_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UndoSendToDBIcon
        {
            get
            {
                var image = Properties.Resources.CancelDatabase_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UndoSendPrintIcon
        {
            get
            {
                var image = Properties.Resources.CancelArticle_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AcceptPgeIcon
        {
            get
            {
                var image = Properties.Resources.AcceptPge_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AcceptOplIcon
        {
            get
            {
                var image = Properties.Resources.AcceptOpl_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AcceptMethodologyIcon
        {
            get
            {
                var image = Properties.Resources.AcceptMethodology_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AcceptQualityOplIcon
        {
            get
            {
                var image = Properties.Resources.AcceptQuality_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon AcceptRpcIcon
        {
            get
            {
                var image = Properties.Resources.AcceptRpc_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RejectPgeIcon
        {
            get
            {
                var image = Properties.Resources.RejectPge_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RejectOplIcon
        {
            get
            {
                var image = Properties.Resources.RejectOpl_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RejectMethodologyIcon
        {
            get
            {
                var image = Properties.Resources.RejectMethodology_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RejectQualityOplIcon
        {
            get
            {
                var image = Properties.Resources.RejectQuality_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon RejectRpcIcon
        {
            get
            {
                var image = Properties.Resources.RejectRpc_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon AcceptedToKipIcon
        {
            get
            {
                var image = Properties.Resources.AcceptedToKip_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon ReturnOrderAcceptedToKipIcon
        {
            get
            {
                var image = Properties.Resources.ReturnOrderAcceptedToKip_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon GetLasIcon
        {
            get
            {
                var image = Properties.Resources.GetLas_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SendMailToCustomerIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/mail/send_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon CheckedIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/content/checkbox_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SendOnCorrectionIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/format/spellcheckasyoutype_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }
        public static Icon SendConclusionToCustIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/mail/emailtemplate_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon TakeInCheckingIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/programming/showtestreport_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon TakeInApprovalIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/format/pictureshapeoutlinecolor_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon SendConclusionRepeatToCustIcon
        {
            get
            {
                var image = Properties.Resources.RepeatTemplate_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon ReprocessingTaskIcon
        {
            get
            {
                var image = Properties.Resources.ReprocessingTask_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }


        public static Icon OnConclusionCheckIcon
        {
            get
            {
                var image = Properties.Resources.OnConclusionCheck_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon PrintIcon
        {
            get
            {
                var image = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/print/print_32x32.png");
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon CheckPgeIcon
        {
            get
            {
                var image = Properties.Resources.CheckPge_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon CheckPeoIcon
        {
            get
            {
                var image = Properties.Resources.CheckPeo_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UnCheckPgeIcon
        {
            get
            {
                var image = Properties.Resources.UnCheckPge_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }

        public static Icon UnCheckPeoIcon
        {
            get
            {
                var image = Properties.Resources.UnCheckPeo_32x32;
                return Icon.FromHandle(new Bitmap(image).GetHicon());
            }
        }
    }
}
