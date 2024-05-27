# Creating the content for the README file
readme_content = """
# MysteryBoxex

MysteryBoxex, kullanıcıların dikkat, hafıza ve hesaplama yeteneklerini ölçen bir "gamification" türünde oyundur.

## Nasıl Oynanır?

1. **Kontroller:**
   - **A ve D Tuşları:** Karakteri yatay eksende hareket ettirir.
   - **Space Tuşu:** Karakteri zıplatır.

2. **Oyun Başlangıcı:**
   - Sayaç bitimiyle birlikte, kullanıcıya hesaplaması gereken hedef bir sayı verilir.

3. **Oyun İçeriği:**
   - Ekranda 9 adet kutu üzerinde rastgele sayılar belirir ve hedef sayı rastgele bir kutuya tanımlanır.
   - Kutularda verilen sayılar 4 saniye görünüp kaybolur.
   - Kullanıcı, bu hesaplamayı hızlı bir şekilde gerçekleştirip hedef sayıyı bulmalıdır.

4. **Can ve Puan Sistemi:**
   - Karakterin 3 canı vardır ve her yanlış kutu veya tuzakla etkileşime girdiğinde bir can kaybeder.
   - Her doğru hedef sayıya ulaşımda, kullanıcının skoru 10'ar 10'ar artar.
   - Karakterin canı bittiğinde veya süresi kalmadığında oyun sona erer ve kullanıcının skoru gösterilir.

## Ekran Görüntüleri

### Başlangıç Ekranı
![Başlangıç Ekranı](https://github.com/muratozkol/Gamification/assets/72967829/77d3b745-d0e1-4414-aff4-cbd850b7fdd4)

### Oyun Ekranı
![Oyun Ekranı 1](https://github.com/muratozkol/Gamification/assets/72967829/86ff0e39-07ca-4110-a5c3-40a5f2359695)
![Oyun Ekranı 2](https://github.com/muratozkol/Gamification/assets/72967829/5123e422-2479-4d4a-a0c0-50dd79c00033)

### Game Over Ekranı
![Game Over Ekranı](https://github.com/muratozkol/Gamification/assets/72967829/bddfbbe3-5ae7-4ef7-8032-028a8ccceacc)
"""

# Writing the content to a txt file
with open("/mnt/data/MysteryBoxex_README.txt", "w") as file:
    file.write(readme_content)
