﻿using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.View.Windows
{
    public partial class AppointmentList : Window, INotifyPropertyChanged
    {

        List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();
        public event PropertyChangedEventHandler PropertyChanged;
        private int selectedIndex=-1;
        public SecretaryScheduleController secretaryScheduleController = new SecretaryScheduleController();
        private Window parent;
        private MainWindowViewModel parentViewModel;

        public List<AppointmentDto> AppointmentDtos
        {
            get { return appointmentDtos; }
            set
            {
                appointmentDtos = value;
                OnPropertyChanged();
            }
        }
        public AppointmentList()
        {
            InitializeComponent();
        }
        public AppointmentList(List<AppointmentDto> listOfAppointments, Window parent, MainWindowViewModel _viewModel)
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentDtos = listOfAppointments;
            this.parent = parent;
            this.parentViewModel = _viewModel;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void selectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedIndex = appointmentListBox.SelectedIndex;
            /*string serialNumber = appointmentDtos[index].Room.SerialNumber;
            EquipmentDetails win = new EquipmentDetails(serialNumber);
            win.Show();*/
        }

        private void createAppointment(object sender, RoutedEventArgs e)
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("You did not selected any appointment !!!");
                return;
            }
            secretaryScheduleController.NewAppointment(appointmentDtos[selectedIndex]);
            MessageBox.Show("You created appointment");
            this.parent.Close();
            this.Close();
        }

        private void showEquipmentButton(object sender, RoutedEventArgs e)
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("You did not selected any appointment !!!");
                return;
            }
            string serialNumber = appointmentDtos[selectedIndex].Room.SerialNumber;
            EquipmentDetails win = new EquipmentDetails(serialNumber);
            win.Show();
        }

        private void goToButtonClick(object sender, RoutedEventArgs e)
        {
            if(selectedIndex == -1)
            {
                MessageBox.Show("You did not selected any appointment !!!");
                return;
            }
            AppointmentDto appointmentDto = appointmentDtos[selectedIndex];
            parentViewModel.CurrentUserControl = parentViewModel.CardiologyBuilding;
            CardiologyFirstFloorMapUserControlViewModel floorViewModel = parentViewModel.CardiologyBuilding.myViewModel.FirstFloor.Viewmodel;
            Button button = floorViewModel.connections[appointmentDto.Room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150, 0, 255));

            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
