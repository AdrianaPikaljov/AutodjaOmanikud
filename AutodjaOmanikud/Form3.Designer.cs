using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        // TAB 1
        private DarkDataGridView dataGridViewCarServices;
        private ComboBox comboBoxCar;
        private ComboBox comboBoxService;
        private DateTimePicker dateTimePickerServiceDate;
        private ModernTextBox textBoxMileage;
        private ModernButton buttonAddService;
        private ModernButton buttonDeleteService;
        private Label labelCar;
        private Label labelService;
        private Label labelDate;
        private Label labelMileage;

        // TAB 2
        private DarkDataGridView dataGridViewPayments;
        private ComboBox comboBoxPaymentCarService;
        private ModernTextBox textBoxPaymentAmount;
        private DateTimePicker dateTimePickerPayment;
        private CheckBox checkBoxPaymentPaid;
        private ModernButton buttonAddPayment;
        private ModernButton buttonDeletePayment;
        private Label labelPaymentCS;
        private Label labelPaymentAmount;
        private Label labelPaymentDate;

        // TAB 3
        private DarkDataGridView dataGridViewBookings;
        private ComboBox comboBoxBookingCar;
        private ComboBox comboBoxBookingService;
        private DateTimePicker dateTimePickerBooking;
        private CheckBox checkBoxBookingCancelled;
        private ModernButton buttonAddBooking;
        private ModernButton buttonCancelBooking;
        private Label labelBookingCar;
        private Label labelBookingService;
        private Label labelBookingDate;

        // Common
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ModernButton button2;
        private ModernButton button3;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            button2 = new ModernButton();
            button3 = new ModernButton();

            SuspendLayout();

            // ===== FORM =====
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.FromArgb(230, 230, 230);
            ClientSize = new Size(900, 580);
            Font = new Font("Segoe UI", 10F);
            Text = "Autode teenused (Dark Neon)";
            StartPosition = FormStartPosition.CenterScreen;

            // ===== TAB CONTROL =====
            tabControl1.Location = new Point(12, 12);
            tabControl1.Size = new Size(860, 520);
            tabControl1.Appearance = TabAppearance.Normal;
            tabControl1.ItemSize = new Size(120, 30);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            tabControl1.TabPages.Add(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.TabPages.Add(tabPage3);

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += (s, e) =>
            {
                var g = e.Graphics;
                var tab = tabControl1.TabPages[e.Index];

                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                Color back = isSelected ? Color.FromArgb(255, 140, 0) : Color.FromArgb(45, 45, 45);
                Color text = isSelected ? Color.Black : Color.FromArgb(230, 230, 230);

                using (Brush b = new SolidBrush(back))
                    g.FillRectangle(b, e.Bounds);

                TextRenderer.DrawText(
                    g,
                    tab.Text,
                    Font,
                    e.Bounds,
                    text,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            // ===== TAB 1 – TEENUSED =====
            tabPage1.Text = "Teenused";
            tabPage1.BackColor = Color.FromArgb(35, 35, 35);

            dataGridViewCarServices = new DarkDataGridView()
            {
                Location = new Point(20, 20),
                Size = new Size(810, 260),
                Name = "dataGridViewCarServices"
            };
            dataGridViewCarServices.CellClick += dataGridViewCarServices_CellClick;

            comboBoxCar = new ComboBox()
            {
                Location = new Point(120, 300),
                Size = new Size(220, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White
            };

            comboBoxService = new ComboBox()
            {
                Location = new Point(120, 340),
                Size = new Size(220, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White
            };

            dateTimePickerServiceDate = new DateTimePicker()
            {
                Location = new Point(120, 380),
                Size = new Size(220, 25),
                Format = DateTimePickerFormat.Short,
                CalendarForeColor = Color.Black
            };

            textBoxMileage = new ModernTextBox()
            {
                Location = new Point(120, 420),
                Size = new Size(220, 28),
                Name = "textBoxMileage"
            };

            labelCar = new Label()
            {
                Location = new Point(20, 304),
                Text = "Auto:",
                AutoSize = true
            };
            labelService = new Label()
            {
                Location = new Point(20, 344),
                Text = "Teenuse:",
                AutoSize = true
            };
            labelDate = new Label()
            {
                Location = new Point(20, 384),
                Text = "Kuupäev:",
                AutoSize = true
            };
            labelMileage = new Label()
            {
                Location = new Point(20, 424),
                Text = "Läbisõit:",
                AutoSize = true
            };

            buttonAddService = new ModernButton()
            {
                Location = new Point(380, 300),
                Size = new Size(130, 40),
                Text = "Lisa teenus",
                Name = "buttonAddService"
            };
            buttonAddService.Click += buttonAddService_Click;

            buttonDeleteService = new ModernButton()
            {
                Location = new Point(380, 350),
                Size = new Size(130, 40),
                Text = "Kustuta teenus",
                Name = "buttonDeleteService"
            };
            buttonDeleteService.Click += buttonDeleteService_Click;

            tabPage1.Controls.Add(dataGridViewCarServices);
            tabPage1.Controls.Add(comboBoxCar);
            tabPage1.Controls.Add(comboBoxService);
            tabPage1.Controls.Add(dateTimePickerServiceDate);
            tabPage1.Controls.Add(textBoxMileage);
            tabPage1.Controls.Add(labelCar);
            tabPage1.Controls.Add(labelService);
            tabPage1.Controls.Add(labelDate);
            tabPage1.Controls.Add(labelMileage);
            tabPage1.Controls.Add(buttonAddService);
            tabPage1.Controls.Add(buttonDeleteService);

            // ===== TAB 2 – MAKSED =====
            tabPage2.Text = "Maksed";
            tabPage2.BackColor = Color.FromArgb(35, 35, 35);

            dataGridViewPayments = new DarkDataGridView()
            {
                Location = new Point(20, 20),
                Size = new Size(810, 260),
                Name = "dataGridViewPayments"
            };
            dataGridViewPayments.CellClick += dataGridViewPayments_CellClick;

            comboBoxPaymentCarService = new ComboBox()
            {
                Location = new Point(170, 300),
                Size = new Size(220, 25),
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            textBoxPaymentAmount = new ModernTextBox()
            {
                Location = new Point(170, 340),
                Size = new Size(220, 28),
                Name = "textBoxPaymentAmount"
            };

            dateTimePickerPayment = new DateTimePicker()
            {
                Location = new Point(170, 380),
                Size = new Size(220, 25),
                Format = DateTimePickerFormat.Short
            };

            checkBoxPaymentPaid = new CheckBox()
            {
                Location = new Point(170, 420),
                Text = "Makstud?",
                AutoSize = true,
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            labelPaymentCS = new Label()
            {
                Location = new Point(20, 304),
                Text = "Teenuse ID:",
                AutoSize = true
            };
            labelPaymentAmount = new Label()
            {
                Location = new Point(20, 344),
                Text = "Summa:",
                AutoSize = true
            };
            labelPaymentDate = new Label()
            {
                Location = new Point(20, 384),
                Text = "Kuupäev:",
                AutoSize = true
            };

            buttonAddPayment = new ModernButton()
            {
                Location = new Point(420, 300),
                Size = new Size(140, 40),
                Text = "Lisa makse",
                Name = "buttonAddPayment"
            };
            buttonAddPayment.Click += buttonAddPayment_Click;

            buttonDeletePayment = new ModernButton()
            {
                Location = new Point(420, 350),
                Size = new Size(140, 40),
                Text = "Kustuta makse",
                Name = "buttonDeletePayment"
            };
            buttonDeletePayment.Click += buttonDeletePayment_Click;

            tabPage2.Controls.Add(dataGridViewPayments);
            tabPage2.Controls.Add(comboBoxPaymentCarService);
            tabPage2.Controls.Add(textBoxPaymentAmount);
            tabPage2.Controls.Add(dateTimePickerPayment);
            tabPage2.Controls.Add(checkBoxPaymentPaid);
            tabPage2.Controls.Add(labelPaymentCS);
            tabPage2.Controls.Add(labelPaymentAmount);
            tabPage2.Controls.Add(labelPaymentDate);
            tabPage2.Controls.Add(buttonAddPayment);
            tabPage2.Controls.Add(buttonDeletePayment);

            // ===== TAB 3 – BRONEERINGUD =====
            tabPage3.Text = "Broneeringud";
            tabPage3.BackColor = Color.FromArgb(35, 35, 35);

            dataGridViewBookings = new DarkDataGridView()
            {
                Location = new Point(20, 20),
                Size = new Size(810, 260),
                Name = "dataGridViewBookings"
            };
            dataGridViewBookings.CellClick += dataGridViewBookings_CellClick;

            comboBoxBookingCar = new ComboBox()
            {
                Location = new Point(140, 300),
                Size = new Size(220, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White
            };

            comboBoxBookingService = new ComboBox()
            {
                Location = new Point(140, 340),
                Size = new Size(220, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White
            };

            dateTimePickerBooking = new DateTimePicker()
            {
                Location = new Point(140, 380),
                Size = new Size(220, 25),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy HH:mm"
            };

            // HOIAME checkboxi koodis, aga teeme nähtamatuks (nagu küsisid)
            checkBoxBookingCancelled = new CheckBox()
            {
                Location = new Point(140, 420),
                Text = "Tühistatud?",
                AutoSize = true,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Visible = false // ei näe vormil, aga kood saab ikka .Checked seada
            };

            labelBookingCar = new Label()
            {
                Location = new Point(20, 304),
                Text = "Auto:",
                AutoSize = true
            };
            labelBookingService = new Label()
            {
                Location = new Point(20, 344),
                Text = "Teenuse:",
                AutoSize = true
            };
            labelBookingDate = new Label()
            {
                Location = new Point(20, 384),
                Text = "Kuupäev:",
                AutoSize = true
            };

            buttonAddBooking = new ModernButton()
            {
                Location = new Point(400, 300),
                Size = new Size(150, 40),
                Text = "Broneeri",
                Name = "buttonAddBooking"
            };
            buttonAddBooking.Click += buttonAddBooking_Click;

            buttonCancelBooking = new ModernButton()
            {
                Location = new Point(400, 350),
                Size = new Size(150, 40),
                Text = "Tühista",
                Name = "buttonCancelBooking"
            };
            buttonCancelBooking.Click += buttonCancelBooking_Click;

            tabPage3.Controls.Add(dataGridViewBookings);
            tabPage3.Controls.Add(comboBoxBookingCar);
            tabPage3.Controls.Add(comboBoxBookingService);
            tabPage3.Controls.Add(dateTimePickerBooking);
            tabPage3.Controls.Add(checkBoxBookingCancelled);
            tabPage3.Controls.Add(labelBookingCar);
            tabPage3.Controls.Add(labelBookingService);
            tabPage3.Controls.Add(labelBookingDate);
            tabPage3.Controls.Add(buttonAddBooking);
            tabPage3.Controls.Add(buttonCancelBooking);

            // ===== ALUMISED NUPUD (NAVIGATSIOON) =====
            button2 = new ModernButton()
            {
                Location = new Point(12, 540),
                Size = new Size(130, 30),
                Text = "Autod",
                Name = "button2"
            };
            button2.Click += button2_Click;

            button3 = new ModernButton()
            {
                Location = new Point(148, 540),
                Size = new Size(130, 30),
                Text = "Omanikud",
                Name = "button3"
            };
            button3.Click += button3_Click;

            // ===== LISA KÕIK VORMILE =====
            Controls.Add(tabControl1);
            Controls.Add(button2);
            Controls.Add(button3);

            ResumeLayout(false);
        }
    }
}
