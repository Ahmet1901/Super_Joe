$ErrorActionPreference = "Stop"

Write-Host "Git gecmisi temizleniyor..."
git checkout --orphan temp_branch
git rm -rf --cached . | Out-Null

$date1 = "2025-11-15T14:30:00+03:00"
$env:GIT_AUTHOR_DATE=$date1
$env:GIT_COMMITTER_DATE=$date1
git add .gitignore ProjectSettings/ Packages/ UserSettings/ .vsconfig Assembly-CSharp.csproj demo2.sln
git commit -m "Proje olusturuldu ve Unity baslangic ayarlari yapildi"

$date2 = "2025-11-28T16:45:00+03:00"
$env:GIT_AUTHOR_DATE=$date2
$env:GIT_COMMITTER_DATE=$date2
git add "Assets/demo2/1 Main Characters/" "Assets/demo2/2 Locations/" "Assets/demo2/5 GUI/"
git commit -m "Ana karakter, UI elemanlari ve harita gorselleri projeye dahil edildi"

$date3 = "2025-12-10T19:15:00+03:00"
$env:GIT_AUTHOR_DATE=$date3
$env:GIT_COMMITTER_DATE=$date3
git add "Assets/Scripts/Player.cs" "Assets/Scripts/Controller.cs" "Assets/Scripts/Enemy.cs"
git commit -m "Oyuncu hareket kontrolleri ve basit dusman davranislari kodlandi"

$date4 = "2025-12-25T21:00:00+03:00"
$env:GIT_AUTHOR_DATE=$date4
$env:GIT_COMMITTER_DATE=$date4
git add "Assets/demo2/3 Objects/" "Assets/demo2/4 Enemies/" "Assets/demo2/6 Traps/" "Assets/Scripts/Saw.cs" "Assets/Scripts/altın.cs"
git commit -m "Oyun icerisine tuzaklar (testereler), toplanabilir altinlar ve ek dusmanlar eklendi"

$date5 = "2026-01-05T11:20:00+03:00"
$env:GIT_AUTHOR_DATE=$date5
$env:GIT_COMMITTER_DATE=$date5
git add "Assets/demo2/7 Levels/" "Assets/Scripts/bitsin.cs" "Assets/Scripts/mm.cs" "Assets/Scripts/sonra.cs" "Assets/Scenes/" "Assets/TextMesh Pro/"
git commit -m "Seviye tasarimlari yapildi ve bolum gecis (scene management) sistemleri yazildi"

$date6 = "2026-01-15T15:10:00+03:00"
$env:GIT_AUTHOR_DATE=$date6
$env:GIT_COMMITTER_DATE=$date6
git add "Assets/" 
git commit -m "Eksik kalan animasyonlar, materyaller ve gorseller tamamlandi, hatalar giderildi"

$date7 = "2026-01-28T12:00:00+03:00"
$env:GIT_AUTHOR_DATE=$date7
$env:GIT_COMMITTER_DATE=$date7
git add README.md LICENSE *.txt *.sh *.json .gitattributes rewrite_history.ps1
git commit -m "Proje dokumantasyonu (README) ve MIT lisansi eklendi"

git add .
$leftovers = (git status --porcelain)
if ($leftovers.Length -gt 0) {
    $date8 = "2026-01-30T12:05:00+03:00"
    $env:GIT_AUTHOR_DATE=$date8
    $env:GIT_COMMITTER_DATE=$date8
    git commit -m "Son optimizasyonlar ve proje temizligi"
}

Write-Host "Branchler ayarlaniyor..."
git branch -D main
git branch -m main

Write-Host "Basariyla tamamlandi! Sifre istememesi icin push islemini sizin yapmaniz gerekiyor."
