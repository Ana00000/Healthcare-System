﻿using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    public partial class BuildingUserControl : UserControl
    {
        private AppointmentController appointmentController = new AppointmentController();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        private RoomRenovationController renovationController = new RoomRenovationController();
        private MainWindowViewModel _viewModel;
        public BuildingUserControlViewModel myViewModel;

        public BuildingUserControl(MainWindowViewModel vm, Building building)
        {
            InitializeComponent();
            _viewModel = vm;
            myViewModel = new BuildingUserControlViewModel(this, vm, building);
            this.DataContext = myViewModel;
        }

        private void ShowRoomSearch(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                new Warning().ShowDialog();
                return;
            }
            RoomSearch roomSearch = new RoomSearch(_viewModel);
            roomSearch.Show();
        }

        private void ShowEquipmentSearch(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                new Warning().ShowDialog();
                return;
            }
            EquipmentSearch equipmentSearch = new EquipmentSearch(_viewModel);
            equipmentSearch.Show();
        }

        private void ShowMedicineSearch(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                new Warning().ShowDialog();
                return;
            }
            MedicineSearch medicineSearch = new MedicineSearch(_viewModel);
            medicineSearch.Show();
        }

        private void SchedulesClick(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.NoUser || MainWindow.TypeOfUser == TypeOfUser.Patient)
            {
                new Warning().ShowDialog();
                return;
            }
            SchedulesWindow schedulesWindow = new SchedulesWindow(appointmentController.GetAll(),
                                                            equipmentRelocationController.GetAll(),
                                                            renovationController.GetAll());
            schedulesWindow.Show();
        }
    }
}
