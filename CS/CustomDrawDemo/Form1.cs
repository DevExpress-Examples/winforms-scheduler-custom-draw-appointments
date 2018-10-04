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
            FillResources(schedulerDataStorage1, 5);
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
        void FillResources(SchedulerDataStorage storage, int count) {
            int cnt = Math.Min(count, Users.Length);
            for (int i = 1; i <= cnt; i++)
                storage.Resources.Items.Add(storage.CreateResource(Guid.NewGuid(), Users[i - 1]));
        }
        void InitAppointments() {
            this.schedulerDataStorage1.Appointments.Mappings.Start = "StartTime";
            this.schedulerDataStorage1.Appointments.Mappings.End = "EndTime";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerDataStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerDataStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerDataStorage1.Appointments.Mappings.ResourceId = "OwnerId";
            this.schedulerDataStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerDataStorage1.Appointments.Mappings.Type = "EventType";

            CustomEventList eventList = new CustomEventList();
            GenerateEvents(eventList);
            this.schedulerDataStorage1.Appointments.DataSource = eventList;

        }
        void GenerateEvents(CustomEventList eventList) {
            int count = schedulerDataStorage1.Resources.Count;
            for (int i = 0; i < count; i++) {
                Resource resource = schedulerDataStorage1.Resources[i];
                string subjPrefix = resource.Caption + "'s ";
                eventList.Add(CreateEvent(eventList, subjPrefix + "meeting", resource.Id, 1, 5));
                eventList.Add(CreateEvent(eventList, subjPrefix + "travel", resource.Id, 4, 6));
                eventList.Add(CreateEvent(eventList, subjPrefix + "phone call", resource.Id, 5, 10));
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
            if (tlvi != null) {
                Rectangle r = e.Bounds;
                r.X += 3;
                r.Y += 3;
                string[] s = tlvi.Appointment.Subject.Split(' ');

                for (int i = 0; i < s.Length; i++) {
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
            if (aptViewInfo == null)
                return;
            if (aptViewInfo.Selected) {
                Rectangle r = e.Bounds;
                Brush brRect = aptViewInfo.Status.GetBrush();
                e.Graphics.FillRectangle(brRect, r);
                e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), r);
                e.Handled = true;
            }
        }
        #endregion #CustomDrawAppointmentBackground
    }
}