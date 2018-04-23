using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#region #usings
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using System.Drawing.Drawing2D;
#endregion #usings

namespace CustomDrawDemo {
    public partial class Form1 : Form {

        #region InitialDataConstants
        public static Random RandomInstance = new Random();
        public static string[] Users = new string[] {"Peter Dolan", "Ryan Fischer", "Richard Fisher", 
                                                 "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", 
                                                 "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", 
                                                 "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"};
        #endregion

        Color[] colorArray = { Color.Red, Color.Green, Color.Blue, Color.Black };

        public Form1() {
            InitializeComponent();
            FillResources(schedulerStorage1, 5);
            InitAppointments();

            schedulerControl1.Start = DateTime.Now;
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.Appearance.Appointment.ForeColor = Color.Gray;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.TimelineView.Scales.Clear();
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleDay());
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleHour());
            schedulerControl1.TimelineView.Scales[1].Width = 100;

            
            UpdateControls();

        }




        #region InitialDataLoad
        void FillResources(SchedulerStorage storage, int count) {
            ResourceCollection resources = storage.Resources.Items;
            storage.BeginUpdate();
            try {
                int cnt = Math.Min(count, Users.Length);
                for (int i = 1; i <= cnt; i++)
                    resources.Add(new Resource(Guid.NewGuid() , Users[i - 1]));
            }
            finally {
                storage.EndUpdate();
            }
        }
        void InitAppointments() {
            this.schedulerStorage1.Appointments.Mappings.Start = "StartTime";
            this.schedulerStorage1.Appointments.Mappings.End = "EndTime";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "OwnerId";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Type = "EventType";

            CustomEventList eventList = new CustomEventList();
            GenerateEvents(eventList);
            this.schedulerStorage1.Appointments.DataSource = eventList;

        }
        void GenerateEvents(CustomEventList eventList) {
            int count = schedulerStorage1.Resources.Count;
            for (int i = 0; i < count; i++) {
                Resource resource = schedulerStorage1.Resources[i];
                string subjPrefix = resource.Caption + "'s ";
                eventList.Add(CreateEvent(eventList, subjPrefix + "meeting", resource.Id, 2, 5));
                eventList.Add(CreateEvent(eventList, subjPrefix + "travel", resource.Id, 3, 6));
                eventList.Add(CreateEvent(eventList, subjPrefix + "phone call", resource.Id, 0, 10));
            }
        }
        CustomEvent CreateEvent(CustomEventList eventList, string subject, object resourceId, int status, int label) {
            CustomEvent apt = new CustomEvent(eventList);
            apt.Subject = subject;
            apt.OwnerId = resourceId;
            Random rnd = RandomInstance;
            int rangeInMinutes = 60 * 24;
            apt.StartTime = DateTime.Today + TimeSpan.FromMinutes(rnd.Next(0, rangeInMinutes));
            apt.EndTime = apt.StartTime + TimeSpan.FromMinutes(rnd.Next(0, rangeInMinutes / 4));
            apt.Status = status;
            apt.Label = label;
            return apt;
        }
        #endregion
        #region Update Controls
        private void UpdateControls() {
            cbView.EditValue = schedulerControl1.ActiveViewType;
            rgrpGrouping.EditValue = schedulerControl1.GroupType;
        }
        private void rgrpGrouping_SelectedIndexChanged(object sender, System.EventArgs e) {
            schedulerControl1.GroupType = (SchedulerGroupType)rgrpGrouping.EditValue;
        }

        private void schedulerControl_ActiveViewChanged(object sender, System.EventArgs e) {
            cbView.EditValue = schedulerControl1.ActiveViewType;
        }

        private void cbView_SelectedIndexChanged(object sender, System.EventArgs e) {
            schedulerControl1.ActiveViewType = (SchedulerViewType)cbView.EditValue;
        }
        #endregion
#region #CustomDrawAppointment
        private void schedulerControl1_CustomDrawAppointment(object sender, CustomDrawObjectEventArgs e) {
            TimeLineAppointmentViewInfo tlvi = e.ObjectInfo as TimeLineAppointmentViewInfo;
            // This code works only for the Timeline View.
            if(tlvi != null) {
                Rectangle r = e.Bounds;
                r.X += 3;
                r.Y += 3;
                string[] s = tlvi.Appointment.Subject.Split(' ');

                for(int i = 0; i < s.Length; i++) {
                    e.Cache.DrawString(s[i], tlvi.Appearance.Font, new SolidBrush(colorArray[i]),
 r, StringFormat.GenericDefault);
                    SizeF shift = e.Graphics.MeasureString(s[i] + " ", tlvi.Appearance.Font);
                    r.X += (int)shift.Width;
                }

                e.Handled = true;
            }
        }
#endregion #CustomDrawAppointment

#region #CustomDrawAppointmentBackground
        private void schedulerControl1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e) {
            DevExpress.XtraScheduler.Drawing.AppointmentViewInfo aptViewInfo = e.ObjectInfo
 as DevExpress.XtraScheduler.Drawing.AppointmentViewInfo;
            if(aptViewInfo == null)
                return;
            if(aptViewInfo.Selected) {
                Rectangle r = e.Bounds;
                Brush brRect = e.Cache.GetSolidBrush(aptViewInfo.Status.Color);
                FillRoundedRect(e.Graphics, brRect, r, 5);
                r.Inflate(-3, -3);
                Color c = Invert(aptViewInfo.Appearance.BackColor); ;
                Brush br = e.Cache.GetSolidBrush(c);
                FillRoundedRect(e.Graphics, br, r, 5);
                e.Handled = true;
            }
        }

        public Color Invert(Color srcColor) {
            byte r = (byte)~(srcColor.R);
            byte g = (byte)~(srcColor.G);
            byte b = (byte)~(srcColor.B);
            return Color.FromArgb(srcColor.A, r, g, b);
        }

        void FillRoundedRect(Graphics gr, Brush br, Rectangle r, int roundRadius) {
            using(Region rgn = new Region(CreateRoundedRectPath(r, roundRadius))) {
                gr.FillRegion(br, rgn);
            }
        }
        static public GraphicsPath CreateRoundedRectPath(Rectangle r, int radius) {
            GraphicsPath path = new GraphicsPath();

            path.AddLine(r.Left + radius, r.Top, r.Left + r.Width - radius * 2, r.Top);
            path.AddArc(r.Left + r.Width - radius * 2, r.Top, radius * 2, radius * 2, 270, 90);
            path.AddLine(r.Left + r.Width, r.Top + radius, r.Left + r.Width, r.Top + r.Height - radius * 2);
            path.AddArc(r.Left + r.Width - radius * 2, r.Top + r.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(r.Left + r.Width - radius * 2, r.Top + r.Height, r.Left + radius, r.Top + r.Height);
            path.AddArc(r.Left, r.Top + r.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(r.Left, r.Top + r.Height - radius * 2, r.Left, r.Top + radius);
            path.AddArc(r.Left, r.Top, radius * 2, radius * 2, 180, 90);
            path.CloseFigure();
            return path;
        }
#endregion #CustomDrawAppointmentBackground

    }
}