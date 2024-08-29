<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633584/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830618)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WinForms Scheduler - Customize the appearance of appointments


This example demonstrates the following techniques to customize the appearance of appointments:

* [HTML-inspired Text Formatting](https://docs.devexpress.com/WindowsForms/4874/common-features/html-text-formatting)
  ```csharp
  Random r = new Random();
  private void schedulerControl1_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e) {
      string[] stringArray = e.Text.Split(' ');
      StringBuilder builder = new StringBuilder();
      foreach(string str in stringArray)
          builder.Append(string.Concat("<color=", r.Next(0, 255), ",", r.Next(0, 255), ",", r.Next(0, 255), ">", str, " ", "</color>"));
      e.Text = builder.ToString();
  }
  ```
* Custom Draw Appointments
  The [CustomDrawAppointmentBackground](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.CustomDrawAppointmentBackground) event is handled to draw the border and invert the background color for selected appointments. In the Timeline View the subject is painted with different colors.

  ```csharp
  private void schedulerControl1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e) {
      AppointmentViewInfo aptViewInfo = e.ObjectInfo as AppointmentViewInfo;
      if(aptViewInfo == null)
          return;
      if(aptViewInfo.Selected) {
          Rectangle r = e.Bounds;
          Brush brRect = aptViewInfo.Status.GetBrush();
          e.Cache.FillRectangle(brRect, r);
          e.Cache.DrawRectangle(Pens.Blue, r);
          e.Handled = true;
      }
  }
  ```

The following screenshot shows the result:

![WinForms Scheduler - Customize the appearance of appointments
](https://raw.githubusercontent.com/DevExpress-Examples/scheduler-control-use-the-custom-draw-appointment-custom-draw-appointment-background-events/19.2.3%2B/media/winforms-scheduler.png)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-custom-draw-appointments&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-custom-draw-appointments&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
