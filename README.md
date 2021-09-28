# AddtoBasketAPI
Bir e-ticaret sitesi için ürün ekleme, listeleme vb. endpointlerin zaten daha önceden yazıldığını varsayılarak sadece sepete ürün ekleme endpointinin bulunduğu, 3 katmanlı mimari içeren bir ASPNET Core 3.1 ile API projesi.

Projede datalar manuel eklenmiştir. Proje çalıştırıldığında "Swagger" ile açılacaktır. Bu eklenti endpoint üzerinde Get, Post işlemlerinin test edilebilmesi oluşturulmuş kolay kullanım sağlayan bir arayüzdür.

Projede BasketController ve StockController, ProductController olmak üzere üç adet Controller bulunmaktadır. Kullanıcıların sepetlerini yönetebilmek için BasketController kullanılır, StockController ise stok durumunu kontrol etmek için kullanılmaktadır, ProductController ürünleri yönetmek için kullanılmaktadır.

Proje Stok kontrolü ile çalışmaktadır. Sepete ürün eklemeye çalıştığınızda stok bulunmuyorsa metottan sepete ürün eklenemedi hatası dönecektir. Çünkü kullanıcı id ve ürün id ile birlikte sepete ürün eklemeye çalıştığımızda, sepete eklenen ürün sayısı kadar stoktan ürün adedi düşülmektedir. Eğer sepete eklenmek istenilen kadar ürün mevcut değilse sepete eklenmeyecektir.
