using CNC.Core.Data;
using CNC.Core.Enums;
using CNC.Core.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC.Forms
{
    public partial class EventManager : Form
    {
        public EventManager()
        {
            InitializeComponent();
            EventControll[] controls = this.flowPanel.Controls.OfType<EventControll>().ToArray();
            Debug.Print(controls.Length.ToString());
            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].eventType.DataSource = Enum.GetValues(typeof(EventType));
                controls[i].eventToExecute.DataSource = Enum.GetValues(typeof(EventDoType));
            }
            LoadEvents();
        }

        public void LoadEvents()
        {
            EventControll[] controls = this.flowPanel.Controls.OfType<EventControll>().ToArray();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cnc", "events.json");

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cnc")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cnc"));
            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(EventControlToEvent(controls)));
                return;
            }

            SetEventControls(JsonConvert.DeserializeObject<Event[]>(File.ReadAllText(path)), this);
            EventManagement.events = JsonConvert.DeserializeObject<Event[]>(File.ReadAllText(path)).ToList();
        }

        public void SaveEvents()
        {
            EventControll[] controls = this.flowPanel.Controls.OfType<EventControll>().ToArray();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cnc", "events.json");

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cnc")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cnc"));
            File.WriteAllText(path, JsonConvert.SerializeObject(EventControlToEvent(controls)));
            EventManagement.events = EventControlToEvent(controls).ToList();
        }

        public static Event[] EventControlToEvent(EventControll[] controls)
        {
            List<Event> events = new List<Event>();
            for (int i = 0; i < controls.Length; i++)
            {
                Event e = new Event()
                {
                    Active = controls[i].chkActive.Checked,
                    DoEvent = (EventDoType)Enum.Parse(typeof(EventDoType), controls[i].eventToExecute.SelectedValue.ToString()),
                    DoEventParams = controls[i].txtEventParam.Text,
                    OnEvent = (EventType)Enum.Parse(typeof(EventType), controls[i].eventType.SelectedValue.ToString())
                };
                events.Add(e);
            }
            return events.ToArray();
        }

        public static void SetEventControls(Event[] events, EventManager instance)
        {
            EventControll[] controls = instance.flowPanel.Controls.OfType<EventControll>().ToArray();
            if (events.Length != controls.Length)
                return;

                for (int i = 0; i < controls.Length; i++)
            {
                controls[i].eventType.SelectedItem = events[i].OnEvent;
                controls[i].eventToExecute.SelectedItem = events[i].DoEvent;
                controls[i].txtEventParam.Text = events[i].DoEventParams;
                controls[i].chkActive.Checked = events[i].Active;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEvents();
        }
    }
}
