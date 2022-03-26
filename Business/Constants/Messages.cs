using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    // Messages sinifi kullaniciya verilecek metotlari standart hale getirmek icin olusturuldu
    // static tanimlandi cunku business katmaninda sinif uzerinden cagrilacak
    // newleme yapilmayacak
    public static class Messages
    {
        public static string productAdded="ürün eklendi";
        public static string ProductNameAlreadyExists="Aynı isimde ürün eklenemez";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string SuccessfulLogin="Sisteme giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string UserAdded="Kullanıcı kaydedildi";
        public static string AccessTokenCreated="Access token oluştuurldu";

        public static string AuthorizationDenied = "Access token oluşturuldu";
    }
}
