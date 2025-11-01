# 🍽️ **SignalR Restoran – .NET Core ile QR Kodlu Gerçek Zamanlı Sipariş Yönetimi**

## 🏗️ **Proje Mimarisi – 6 Katmanlı Temiz Mimari**
Uygulama, **SOLID** ve **Clean Code** prensipleri doğrultusunda katmanlı bir yapı üzerine inşa edilmiştir.  
Her katman, yalnızca kendi sorumluluk alanındaki görevleri üstlenmektedir.

---

### 🧠 **Business Katmanı**
- Tüm iş kuralları, validasyonlar ve özel senaryolar burada tanımlanmıştır.  
- Servis arayüzleri ile bağımlılıklar minimuma indirilmiştir.  
- CRUD işlemleri ve özel iş mantıkları burada yürütülür.

### 💾 **Data Access Katmanı**
- Veritabanı işlemleri **Entity Framework Core** ile gerçekleştirilmiştir.  
- **Repository Pattern** yapısı kullanılmıştır.  
- **LINQ** sorguları ile listeleme ve filtreleme işlemleri optimize edilmiştir.

### 📦 **DTO Katmanı**
- Katmanlar arası veri aktarımında kullanılan sadeleştirilmiş veri modelleridir.  
- Performans artışı ve veri güvenliği sağlar.

### 🧱 **Entity Katmanı**
- Sistemdeki ana varlık sınıfları bu katmanda yer alır.  
  Örneğin: `Product`, `Category`, `Order`, `Reservation` vb.

### 🔗 **API Katmanı**
- Tüm veri işlemleri **RESTful API** yapısı üzerinden gerçekleştirilir.  
- **Swagger** ile uç noktalar test edilebilir.  
- API sadece kontrollü erişim sağlar; doğrudan veri tabanı erişimi yoktur.

### 🌐 **Web UI Katmanı**
- Kullanıcı arayüzü **Razor Pages**, **AJAX**, **jQuery** ve **SignalR** ile geliştirilmiştir.  
- Gerçek zamanlı, mobil uyumlu ve kullanıcı dostu bir arayüz sunar.

---

## ⚙️ **Kullanılan Teknolojiler**
- ASP.NET Core Web API  
- Entity Framework Core  
- SignalR  
- Fluent Validation  
- ASP.NET Core Identity (AppUser ile genişletilmiş)  
- MailKit (Gerçek mail gönderimi)  
- QR Code Generator  
- Swagger  
- LINQ  
- AJAX & JavaScript  

---

## 🔄 **SignalR ile Gerçek Zamanlı Özellikler**

### 🔔 **Rezervasyon Bildirimi**
- Her 5 saniyede bir yeni rezervasyon kontrolü yapılır.  
- Yeni kayıt varsa kullanıcıya anlık bildirim gönderilir.

### 🛎️ **Masa Durumu Takibi**
- Masaların “Boş” veya “Dolu” durumu anlık olarak renk değişimiyle görüntülenir.  
- Masa durumu değiştiğinde tüm istemcilere canlı olarak yansıtılır.

### 💬 **Anlık Mesajlaşma**
- Kullanıcılar arası sohbet, `chat.js` dosyası aracılığıyla canlı şekilde yapılabilir.

### 📊 **Dinamik İstatistikler**
- Kategori başına ürün sayısı  
- En yüksek ve en düşük fiyatlı ürün  
- Ortalama ürün fiyatı  
- Aktif ve toplam sipariş sayısı  
- Son sipariş tutarı  
> Tüm veriler **SignalR** aracılığıyla sayfa yenilemeden güncellenir.

---

## 🌍 **Harita & Navigasyon**
- **Google Maps API** entegrasyonu sayesinde restoran konumu harita üzerinde gösterilir.  
- Kullanıcılar haritadan restoran yol tarifini görüntüleyebilir.

---

## 🔐 **Oturum & Güvenlik Yönetimi**
- **ASP.NET Identity** kullanılarak kullanıcı kimlik doğrulama sistemi kurulmuştur.  
- `AppUser` sınıfı genişletilerek ek kullanıcı bilgileri eklenmiştir (Ad, Soyad vb.).  
- Kimlik doğrulama ve rol bazlı yetkilendirme aktif olarak kullanılmaktadır.  
- Oluşturulan tablolar:  
  - `AspNetUsers`  
  - `AspNetRoles`  
  - `AspNetUserRoles`  
  - `AspNetUserClaims`  
  - `AspNetRoleClaims`  
  - `AspNetUserLogins`  
  - `AspNetUserTokens`

---

## ✉️ **Mail İşlemleri (MailKit)**
- Google API Key üzerinden gerçek mail gönderimi yapılabilmektedir.  
- Rezervasyon ve şifre yenileme gibi durumlarda otomatik mail gönderimi mümkündür.

---

## ⚠️ **Özel Hata Sayfaları**
- 404 gibi geçersiz sayfa isteklerinde kullanıcıyı yönlendiren modern bir hata sayfası tasarlanmıştır.  
- Kullanıcı deneyimi göz önüne alınarak rehberlik sağlayan yönlendirmeler eklenmiştir.

---

## 🛡️ **Yetkilendirme & Erişim Kontrolü**
- Giriş yapmamış kullanıcılar otomatik olarak login ekranına yönlendirilir.  
- Yönetici paneline yalnızca gerekli role sahip kullanıcılar erişebilir.

---

## 📦 **Ek Özellikler**
- 📱 **QR Kod Üretimi:** Masalar ve menüler için özel QR kod oluşturma.  
- 🌐 **RapidAPI Tasty Entegrasyonu:** Dünya mutfağına ait yemek tarifleri ve videolar.  
- 🔄 **Trigger Kullanımı:** Sipariş durumlarına göre özel aksiyonlar.  
- ⚙️ **AJAX İşlemleri:** Ürün işlemleri anlık ve sayfa yenilemeden yapılır.  
- 🧩 **Fluent Validation:** Eksik form alanları için kullanıcı uyarı sistemi.

---

## 👤 **Kullanıcı Arayüzünde Yapılabilenler**
- Menü inceleme, rezervasyon oluşturma  
- Masa seçerek sipariş verme ve ödeme işlemleri  
- Restoran konumuna ve iletişim bilgilerine erişim

---

## 🧭 **Yönetici Paneli Özellikleri**
- **Dashboard:** Anlık masa durumu, aktif sipariş sayısı, toplam sipariş, boş masa sayısı gibi veriler SignalR ile canlı olarak gösterilir.  
- **Bildirimler:** Yeni rezervasyon ve sipariş bildirimleri anlık olarak gelir.  
- **CRUD İşlemleri:** Kategori, Ürün, İndirim, Sosyal Medya, Hakkımda, Mail ve Bildirim modüllerinde tüm işlemler yapılabilir.  
- **İstatistikler:** Fiyat, kategori, sipariş gibi tüm analizler anlık olarak güncellenir.  
- **QR Kod Üretimi:** Masalar için dinamik QR kod oluşturma.  
- **Profil Ayarları:** Yönetici kişisel bilgilerini güncelleyebilir.

---

## 🖼️ **Proje Görüntüleri**
<img width="1900" height="865" alt="Ekran görüntüsü 2025-10-29 162531" src="https://github.com/user-attachments/assets/70277859-812b-4a30-a9e6-5e00e56bd1f1" />
<img width="1904" height="909" alt="Ekran görüntüsü 2025-10-29 162955" src="https://github.com/user-attachments/assets/0eab88fc-03d9-438e-b51d-e83a1629434c" />
<img width="1901" height="755" alt="Ekran görüntüsü 2025-10-29 163033" src="https://github.com/user-attachments/assets/dc9f69b4-e25b-41ff-b5e0-fb44861f5e6f" />
<img width="1905" height="904" alt="Ekran görüntüsü 2025-10-29 163131" src="https://github.com/user-attachments/assets/01d75c8c-55b0-4b23-abc1-92da234c684f" />
<img width="1903" height="911" alt="Ekran görüntüsü 2025-10-29 164009" src="https://github.com/user-attachments/assets/da5ed295-f9da-4cf1-8322-3cc13b94ac62" />
<img width="1903" height="905" alt="Ekran görüntüsü 2025-10-29 164128" src="https://github.com/user-attachments/assets/610ab69b-a979-45e3-b04a-b93196c26c0e" />
<img width="1111" height="544" alt="Ekran görüntüsü 2025-10-29 164304" src="https://github.com/user-attachments/assets/6dc9bfcf-af32-4a27-a04b-d9a471e70e12" />
<img width="1919" height="905" alt="Ekran görüntüsü 2025-10-29 164333" src="https://github.com/user-attachments/assets/0a7c629e-d796-42d1-86c5-a88df499e9a5" />
<img width="1905" height="911" alt="Ekran görüntüsü 2025-10-29 164535" src="https://github.com/user-attachments/assets/eee3b63a-c77d-4183-b7cf-a2bcc146891f" />
<img width="1919" height="910" alt="Ekran görüntüsü 2025-10-29 164609" src="https://github.com/user-attachments/assets/1c05314d-0dbb-4616-a7bc-2a1d9c178c7f" />
<img width="1903" height="906" alt="Ekran görüntüsü 2025-10-29 164643" src="https://github.com/user-attachments/assets/178c4b30-97e5-4a58-9be1-0eab32802228" />
<img width="1906" height="901" alt="Ekran görüntüsü 2025-10-29 164742" src="https://github.com/user-attachments/assets/f4bff47c-3153-4dc7-9188-844382d79c00" />
<img width="1904" height="905" alt="Ekran görüntüsü 2025-10-29 164815" src="https://github.com/user-attachments/assets/d86c5436-6060-4cfd-9f85-86318dd5a4e9" />
<img width="1918" height="910" alt="Ekran görüntüsü 2025-10-29 164904" src="https://github.com/user-attachments/assets/be208c46-fa55-42d8-a465-dfd89a8996b8" />
<img width="1912" height="909" alt="Ekran görüntüsü 2025-10-29 164804" src="https://github.com/user-attachments/assets/63134004-15fe-4be9-bf6f-43fd1f1de41c" />

