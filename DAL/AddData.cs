using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddData
    {
        //Loại đĩa
        public static List<eDiskType> GetDiskTypes()
        {
            List<eDiskType> eDiskTitles = new List<eDiskType>()
            {
                new eDiskType()
                {
                   diskTypeId = "GAMES",
                   diskName = "Đĩa game",
                   rentalCharge = 20000,
                   lateFee = 2000,
                   rentalPeriod = 7
                },
                new eDiskType()
                {
                   diskTypeId = "MOVIES",
                   diskName = "Đĩa phim",
                   rentalCharge = 15000,
                     lateFee = 1500,
                   rentalPeriod = 10
                },

            };
            return eDiskTitles;
        }

        //Tựa đĩa
        public static List<eDiskTitle> GetDiskTitles()
        {
            List<eDiskTitle> eDiskTitles = new List<eDiskTitle>()
            {
                //Tựa đề phim
                new eDiskTitle()
                {
                   diskTitleName = "The Shawshank Redemption",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "The Godfather",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Pulp Fiction",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "The Dark Knight",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Titanic",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Avatar",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Lion King",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "ET - The Extra Terrestrial",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Lord of the Rings: The Fellowship of the Ring",
                   diskTypeId = "MOVIES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Home Alone",
                   diskTypeId = "MOVIES"
                },

                //Tựa game
                new eDiskTitle()
                {
                   diskTitleName = "Call of Duty",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Half-Life 2",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "BioShock",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Batman: Arkham Asylum",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Mass Effect 2",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Portal",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "The Last of Us",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Fallout",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "God of War",
                   diskTypeId = "GAMES"
                },
                new eDiskTitle()
                {
                   diskTitleName = "Grand Theft Auto V",
                   diskTypeId = "GAMES"
                },

            };
            return eDiskTitles;
        }

        //Đĩa
        public static List<eDisk> GetDisks()
        {
            List<eDisk> eDisks = new List<eDisk>()
            {
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 1
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 2
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 3
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 4
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 5
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 6
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 7
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 8
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 9
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 10
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 11
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 12
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 13
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 14
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 15
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 1
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 1
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 2
                },
                new eDisk()
                {
                   status = "Trên kệ",
                   dateAdd = DateTime.Now,
                   diskTitleId = 2
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 15
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 5
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 5
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 10
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 10
                },
                new eDisk()
                {
                   status = "Cho thuê",
                   dateAdd = DateTime.Now,
                   diskTitleId = 10
                },
            };
            return eDisks;
        }

        //Khách hàng
        public static List<eCustomer> GetCustomer()
        {
            List<eCustomer> eCustomers = new List<eCustomer>()
            {
                new eCustomer()
                {
                   customerName = "Võ Tuấn Phương",
                   customerAddress = "311/Bùi Thị Xuân - TP.Phan Thiết - Tỉnh Bình Thuận",
                   customerPhone = "0984544711"
                },
                new eCustomer()
                {
                   customerName = "Bùi Đức Thiện",
                   customerAddress = "1/Ngô Quyền - TP.Cam Ranh - Tỉnh Khánh Hòa",
                   customerPhone = "0984544711"
                },
                new eCustomer()
                {
                   customerName = "Nguyễn Vĩnh Long Vinh",
                   customerAddress = "5/Phạm Văn Đồng - Q.Thủ Đức - TP.Hồ Chí Minh",
                   customerPhone = "0984544711"
                },
                new eCustomer()
                {
                   customerName = "Phan Trọng Hinh",
                   customerAddress = "1/Lê Thánh Tôn - Q.Tân Bình - TP.Hồ Chí Minh",
                   customerPhone = "0984544711"
                },
            };
            return eCustomers;
        }

        //Phiếu thuê
        public static List<eRentalBill> GetRentalBill()
        {
            List<eRentalBill> eRentalBills = new List<eRentalBill>()
            {
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,10,5),
                   paymentTerm = new DateTime(2020,10,15),
                   payDate = new DateTime(2020,10,5),
                   customerID = 1,
                   diskId = 3
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,5,7),
                   paymentTerm = new DateTime(2020,10,17),
                   payDate = new DateTime(2020,5,7),
                   customerID = 1,
                   diskId = 5
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,11,1),
                   paymentTerm = new DateTime(2020,11,10),
                   payDate = new DateTime(2020,11,1),
                   customerID = 1,
                   diskId = 16
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,11,11),
                   paymentTerm = new DateTime(2020,11,20),
                   payDate = new DateTime(2020,11,11),
                   customerID = 1,
                   diskId = 21
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,4,5),
                   paymentTerm = new DateTime(2020,4,15),
                   payDate = new DateTime(2020,4,5),
                   customerID = 1,
                   diskId = 22
                },

                new eRentalBill()
                {
                   hireDate = new DateTime(2020,10,1),
                   paymentTerm = new DateTime(2020,10,10),
                   payDate = new DateTime(2020,10,1),
                   customerID = 2,
                   diskId = 18
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,11,9),
                   paymentTerm = new DateTime(2020,11,20),
                   payDate = new DateTime(2020,11,9),
                   customerID = 2,
                   diskId = 17
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,11,15),
                   paymentTerm = new DateTime(2020,11,25),
                   payDate =  new DateTime(2020,11,15),
                   customerID = 3,
                   diskId = 23
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,12,1),
                   paymentTerm = new DateTime(2020,12,7),
                   payDate = new DateTime(2020,12,1),
                   customerID = 3,
                   diskId = 25
                },
                new eRentalBill()
                {
                   hireDate = new DateTime(2020,9,2),
                   paymentTerm = new DateTime(2020,9,12),
                   payDate = new DateTime(2020,9,2),
                   customerID = 4,
                   diskId = 20
                },
            };
            return eRentalBills;
        }

        //Phí phạt
        public static List<eLateCharge> GetLateCharges()
        {
            List<eLateCharge> eLateCharges = new List<eLateCharge>()
            {
                new eLateCharge()
                {
                   lateFee = 2000,
                   status = false,
                   rentalBillId = 1
                },
                 new eLateCharge()
                {
                   lateFee = 2000,
                   status = false,
                   rentalBillId = 2
                },
                  new eLateCharge()
                {
                   lateFee = 2000,
                   status = false,
                   rentalBillId = 3
                },
                   new eLateCharge()
                {
                   lateFee = 1500,
                   status = false,
                   rentalBillId = 4
                },
                    new eLateCharge()
                {
                   lateFee = 1500,
                   status = false,
                   rentalBillId = 5
                },

            };
            return eLateCharges;
        }

        //Đặt trước
        public static List<eReservation> GetReservations()
        {
            List<eReservation> eReservations = new List<eReservation>()
            {
                new eReservation()
                {
                   dateOrder = new DateTime(2020,11,1),
                   diskTitleId = 1,
                   customerID = 1
                },
                new eReservation()
                {
                   dateOrder = new DateTime(2020,11,5),
                   diskTitleId = 1,
                   customerID = 2
                },
                new eReservation()
                {
                   dateOrder = new DateTime(2020,11,15),
                   diskTitleId = 1,
                   customerID = 3
                },
                new eReservation()
                {
                   dateOrder = new DateTime(2020,11,20),
                   diskTitleId = 1,
                   customerID = 4
                },
            };
            return eReservations;
        }
    }
}
