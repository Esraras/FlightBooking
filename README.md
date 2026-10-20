# FlightBooking

Uçuş rezervasyon ve operasyon yönetimi için geliştirilmiş ASP.NET Core MVC uygulamasıdır. Sistem, uçuşların yönetimini, rezervasyon işlemlerini, check-in akışını, talep tahmini ve no-show/overbooking analitiğini tek bir platformda sunar.

## Özellikler

- Uçuş listesi ve detay ekranları
- Admin paneli üzerinden uçuş oluşturma / yönetim
- Rezervasyon oluşturma ve yolcu bilgisi takibi
- Check-in süreci ve PNR/PNR benzeri iş akışı
- MongoDB tabanlı veri saklama
- Makine öğrenmesi tabanlı uçuş talep tahmini
- No-show oranı analizi ve overbooking önerileri
- Dinamik dashboard / öneri ekranları

## Teknoloji Yığını

- ASP.NET Core MVC
- .NET 10
- MongoDB.Driver
- AutoMapper
- Microsoft ML (Machine Learning)
- Bootstrap / ASP.NET View yapısı

## Proje Yapısı

```text
FlightBooking/
├── FlightBooking/
│   ├── Areas/
│   │   └── Admin/
│   │       ├── Controllers/
│   │       ├── ViewComponents/
│   │       └── Views/
│   ├── Controllers/
│   ├── Dtos/
│   ├── Entities/
│   ├── Mapping/
│   ├── Models/
│   ├── Services/
│   │   ├── BookingServices/
│   │   ├── CheckInService/
│   │   ├── FlightServices/
│   │   ├── MachineLearningServices/
│   │   └── NoShowServices/
│   ├── Settings/
│   ├── Views/
│   ├── wwwroot/
│   ├── appsettings.json
│   ├── Program.cs
│   ├── FlightBooking.csproj
│   └── .env.example
├── FligthBooking.slnx
└── README.md
```

## Çalıştırma Öncesi Gereksinimler

- .NET SDK 10 kurulmuş olmalıdır
- MongoDB sunucusu veya MongoDB Atlas hesabı hazır olmalıdır
- Uygulama için gerekli veritabanı ayarları yapılmalıdır

## Yapılandırma

Uygulama `appsettings.json` üzerinden temel MongoDB yapılandırmasını okur. Ayrıca ortam değişkenleri de desteklenmektedir.

### Örnek ortam değişkenleri

```env
MONGODB_URI="mongodb://localhost:27017"
MONGODB_DATABASE="FlightBookingDB"
MONGODB_COLLECTION="Flights"
MONGODB_BOOKING_COLLECTION="Bookings"
MONGODB_CHECKIN_COLLECTION="CheckIns"
MONGODB_FLIGHT_DEMAND_COLLECTION="FlightDemandHistories"
MONGODB_NOSHOW_HISTORY_COLLECTION="NoShowHistories"
```

`FlightBooking/.env.example` dosyasını inceleyerek kendi ortamınıza uygun değerleri ekleyebilirsiniz.

## Çalıştırma

Projeyi çalıştırmak için kök dizinde şu komutları kullanabilirsiniz:

```bash
dotnet restore
cd FlightBooking
dotnet run
```

Alternatif olarak doğrudan proje klasöründen de çalıştırabilirsiniz:

```bash
dotnet run --project FlightBooking/FlightBooking.csproj
```

Uygulama varsayılan olarak ASP.NET Core uygulama sunucusunu başlatacak ve MVC rotaları ile açılacaktır.

## Ana Modüller

### 1. Uçuş Yönetimi
Admin alanı üzerinden yeni uçuşlar eklenebilir, mevcut uçuşlar listelenebilir ve detaylara erişilebilir.

### 2. Rezervasyon
Yolcu bilgileri ile birlikte rezervasyon iş akışı oluşturulur. Her rezervasyon, uçuş bilgisi ve yolcu verisi ile ilişkilendirilir.

### 3. Check-in
Yolcu için check-in işlemi gerçekleştirilir. Uçuş bilgisi ve yolcu bilgileri aynı ekran üzerinden görüntülenebilir.

### 4. Talep Tahmini
Makine öğrenmesi modeli kullanılarak uçuş yoğunluğu tahmini yapılır. Bu tahmin, uçuş doluluk ihtimalini yorumlamak için kullanılabilir.

### 5. No-show ve Overbooking Analizi
No-show verileri ve uçuş saat aralıklarına göre, kapasite yönetimi için öneriler üretilir. Bu sayede aşırı satış (overbooking) kararları için destek sunar.

## Geliştirme Notları

- Veritabanı katmanı MongoDB için tasarlanmıştır.
- Her iş akışı servis katmanları üzerinden yönetilir.
- Admin işlemleri `Areas/Admin` klasörü altında yer alır.
- Machine learning kodları `Services/MachineLearningServices` altında bulunur.

## Katkı

Katkı sağlamak isterseniz, aşağıdaki adımları takip edebilirsiniz:

1. Depoyu fork'layın
2. Yeni bir branch oluşturun
3. Değişikliklerinizi yapın
4. Pull request açın

## Lisans

Bu proje için özel lisans bilgisi tanımlanmamıştır. Kendi ortamınızda kullanmadan önce lisans koşullarını kontrol edin.
