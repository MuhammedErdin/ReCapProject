using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarsListed = "Araçlar listelendi";
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted = "Araç başarıyla silindi";
        public static string CarUpdated = "Araç başarıyla güncellendi";
        public static string CarNameMustContainOnlyLetter = "Araç adı sadece karakterlerden oluşmalı";

        public static string ColorsListed = "Renkler listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk başarıyla silindi";
        public static string ColorUpdated = "Renk başarıyla güncellendi";
        public static string ColorNameInvalid = "Renk tanımlanamadı";
        public static string ColorNameMustContainOnlyLetter = "Renk adı sadece karakterlerden oluşmalı";

        public static string BrandsListed = "Markalar listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka başarıyla silindi";
        public static string BrandUpdated = "Marka başarıyla güncellendi";
        public static string BrandNameInvalid = "Marka tanımlanamadı";
        public static string BrandNameMustContainOnlyLetter = "Marka adı sadece karakterlerden oluşmalı";

        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı başarıyla silindi";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi";
        public static string UserNameInvalid = "Müşteri tanımlanamadı";
        public static string FirstNameMustContainOnlyLetter = "Kullanıcı adı sadece karakterlerden oluşmalı";
        public static string LastNameMustContainOnlyLetter = "Kullanıcı soyadı sadece karakterlerden oluşmalı";


        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri başarıyla silindi";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi";
        public static string CustomerNameInvalid = "Müşteri tanımlanamadı";

        public static string RentalsListed = "Kiralama işlemleri listelendi";
        public static string RentalAdded = "Kiralama işlemi eklendi";
        public static string RentalDeleted = "Kiralama işlemi başarıyla silindi";
        public static string RentalUpdated = "Kiralama işlemi başarıyla güncellendi";
        public static string RentalInvalid = "Kiralama işlemi başarısız";
        public static string NoAvailableRentals = "Mevcut kiralama işlemi yok";
        public static string NoRentalsFound = "Kiralama işlemi bulunamadı";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarDeliver = "Araç teslim edildi";
        public static string CarDeliverEmpty = "Araç teslim edilemedi";
        public static string Invalid = "Geçersiz İşlem!";

        public static string ImageLimitExceeded = "Bu araba için daha fazla resim ekleyemezsiniz. Bir arabanın en fazla 5 resmi olabilir!";
        public static string ImagesListed = "Araç resimleri listelendi";
        public static string ImageAdded = "Araç resmi eklendi";
        public static string ImageUpdated = "Araba resmi başarıyla yüklendi.";
        public static string ImageDeleted = "Araba resmi başarıyla silindi.";
        public static string ImagesListedById = "ID'ye göre listelendi";
        public static string ImagesListedByCarId = "Araç ID'sine göre listelendi";
        public static string CarImageLimitReached = "Araç resim sınırına ulaşıldı";
        public static string ImageAlreadyHave = "Resim zaten var";
    }
}
