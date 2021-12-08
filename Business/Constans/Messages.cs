using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public class Messages
    {
        public static string SaleAdded = "Satış Eklendi";
        public static string SaleListed = "Satış Listesine Eklendi";
        public static string SaleDeleted = "Satış Silindi";
        public static string  ItemsListed="Kategori Listelendi";
        public static string CategoryAdded="Kategori Eklendi";
        public static string CategoryDeleted="Kategori Silindi";
        public static string UserAdded="Kullanıcı Eklendi";
        public static string CategoryListed="Kategori Listelendi";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string CategoryUpdated="Kategori Güncellendi";
        public static string UserUpdated="Kullanıcı Güncellendi";
        public static string ProductDeleted="Ürün Silindi";
        public static string ProductAdded="Ürün Eklendi";
        public static string ProductUpdated="Ürün Güncelledi";
        public static string  ProductListed="Ürün Listelendi";
        public static string CategoryListedId="Katagori verilen Id değerine göre Listelendi";
        public static string ProductListedId= "Verilen Id değerine göre Listelendi";
        public static string ProductListedDetail="Ürün Listesi";
        public static string SaleUptaded="Satış Güncellendi";
        public static string UserListed="Kullanıcı Listelendi";
        public static string UserListedId="Verilen Id değerine göre listelendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme Giriş Başarılı";
        public static string UserAlreadyExists = "Bu Kullanıcı Zaten Mevcut";
        public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";
        public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu";
        public static string ImageAdded="Resim Eklendi";
        public static string ImageUpdated="Resim Güncellendi";
        public static string ImageDeleted="Resim Silindi";
        public static string AuthorizationDenied="Yetkiniz yok!";
    }
}
