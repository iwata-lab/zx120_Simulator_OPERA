# Simulator on Unity + PhysX communicating with ROS

これは,Unity と PhysX を使用し,ROS と通信する遠隔操縦シミュレータです．zx120の遠隔操縦がメインになっています．

# 概要

このシミュレータは,[土木研究所](https://www.pwri.go.jp/)が提供する[OPERA（Open Platform for Engineering Resources of Applications）](https://www.pwri.go.jp/team/advanced/opera.html)をベースにしています.OPERAは,建設機械の自動化・自律化のための研究開発プラットフォームです．OPERAプロジェクト内で使用されています．

- OPERA GitHubリポジトリ: [https://github.com/PWRIEarthquakeLab/OPERA](https://github.com/pwri-opera)

# インストール方法
詳しくは元のOPERAシミュレータのリンクを参照
1. Unity(ver:2022.3.4f1)のダウンロード
2. UnityHubからダウンロードしたシミュレータを開く
3. `Asset/Scenes/SampleScene.unity`を開く

# 本シミュレータの特徴

## zx120用遠隔操縦ステージの作成
zx120の遠隔操縦を目的としたステージの作成を行いました．

![image](https://github.com/user-attachments/assets/e7f3bc5c-9523-4801-8b0b-a4207cec0ee5)

ゲームシーンを再生すると，以下のような3画面から構成される画面を見ながらzx120の操縦を行うことができます．
![image](https://github.com/user-attachments/assets/733481ed-3275-416d-84bb-88f30c79ed33)

## 固形対象物の把持配置
油圧ショベルによる標準的な作業として，主に実現場での掘削積込作業を想定したモデルタスクとして，固形対象物の把持配置タスクを設定しました．ここでは，油圧ショベルは作業対象の前まで走行し，対象物をアーム，ブーム，バケットを操縦して持ち上げ，所定の位置に配置することを一連のタスクとしています．

https://github.com/user-attachments/assets/594ff280-bc0f-40fd-80a2-77bc051fcb2c

土木研究所　技術推進本部先端技術チーム，「大規模土砂災害等に対する迅速かつ安全な機械施工に関する研究」
https://www.pwri.go.jp/jpn/results/report/report-project/2013/pdf/pro-2-7.pdf

## 掘削作業
土砂に見立てたボールプールを作成し，掘削積込のタスクを設定しました．zx120から多くの土砂を積み上げ，ダンプに積み込むまでを一連のタスクとしています．

https://github.com/user-attachments/assets/2b3dbe2b-4023-41fe-b112-999f9a82d218

## サウンドの追加
操縦時の駆動音や，障害物に衝突したときのサウンドを付与しています．
zx120は”Obstacle”のタグがついたオブジェクトに衝突したときのみサウンドを再生するように設定されています．

## 景観の設定
草木を配置しました．実験時に不要な場合は`Hierarchy`内の`Trees`を非表示にしてください．


# 油圧ショベルの操縦
本シミュレータでは縦旋回と呼ばれる操縦方式を採用しています．

## ROSを使用しない場合
`Hierarchy`内の`zx120Controller`というオブジェクト内の`zx120Controller.cs`から操縦方法を選択することができます．

![image](https://github.com/user-attachments/assets/0a7167f6-98bb-4122-9842-5b1b73daabfc)

### キーボードを使用した方式
IsKeyboardControlのチェックボックスを選択してください．
油圧ショベルの操縦をキーボードで行えるように設定しました．

- I/K: ブーム上下
- E/D: スイング左右
- F/A: アーム伸縮
- J/L: バケット開閉
- T/G: 左クローラ前進，後退
- Y/H: 右クローラ前進，後退
![Key](https://github.com/user-attachments/assets/2fab472a-a50c-430f-a65f-53eabd933a49)


### コントローラを3つ使用する方式
ゲームパッドと，フライトスティック2つを用意し，実際の建設機械の遠隔操縦用のコントローラと操縦感を近づけた方式を用意しました．
IsControllerControlのチェックボックスを選択してください．
操縦方法は以下の図のようになっています．

![image](https://github.com/user-attachments/assets/6231697e-c242-41cc-a2b4-964f099b35cf)

注意：Unity上でゲームパッドをJoystick1，左側のフライトスティックをJoystick2，右側のフライトスティックをJoystick3と割り当てています．Unityを起動してから順番にUSBポートに接続することで適切な順番で割り当てが行われます．

実際に我々が使用しているフライトスティックは[こちら](https://www.amazon.co.jp/%E3%82%B9%E3%83%A9%E3%82%B9%E3%83%88%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC-Sidestick-%E3%83%95%E3%83%A9%E3%82%A4%E3%83%88%E3%82%B9%E3%83%86%E3%82%A3%E3%83%83%E3%82%AF-%E3%80%90%E6%97%A5%E6%9C%AC%E6%AD%A3%E8%A6%8F%E4%BB%A3%E7%90%86%E5%BA%97%E4%BF%9D%E8%A8%BC%E5%93%81%E3%80%91-2960844/dp/B08CVN13CX/ref=sr_1_8?__mk_ja_JP=%E3%82%AB%E3%82%BF%E3%82%AB%E3%83%8A&crid=233Y73FRX0N7&dib=eyJ2IjoiMSJ9.6lPdfsCNHN7yZzZt7DilJUhFuYJstwIaYNPjDnSL6T49I0MYZjVES9BiX271v3BExktOcWbsXiy2RB5zzngER9YzB9kXuxUvB4nOMrVTqB4Mrib8AAOB7E3ATu3_VfFO1lYSFETow4cB3GdOoA27ZLFkG9XX6eQ-iEtMjhc9Ka7QQ-cVtl6J_aWzHgIGCzqrZsVjg2KJ_0gotjW-DLZMD-icjvnGkcutk9BEKEcXjPeb53PzcSJOikPrWgMnGSaos-r0xknpbkos_Rwks_EFkMaMePTvVA3bQu5wYEkgSmw.dd2mHtL7JyVcUZYgpUJ-OiNFNqNuBTA-4CUdiec5Afg&dib_tag=se&keywords=%E4%BA%BA%E6%B0%97%E3%81%AE%E3%83%95%E3%83%A9%E3%82%A4%E3%83%88%E3%82%B3%E3%83%B3%E3%83%88%E3%83%AD%E3%83%BC%E3%83%A9%E3%83%BC%E3%83%A9%E3%83%B3%E3%82%AD%E3%83%B3%E3%82%B0+Airbus&qid=1724231952&sprefix=%E4%BA%BA%E6%B0%97%E3%81%AE%E3%83%95%E3%83%A9%E3%82%A4%E3%83%88%E3%82%B3%E3%83%B3%E3%83%88%E3%83%AD%E3%83%BC%E3%83%A9%E3%83%BC%E3%83%A9%E3%83%B3%E3%82%AD%E3%83%B3%E3%82%B0+airbus%2Caps%2C163&sr=8-8)です．

### ゲームパッド1つで操縦を行う方式
ゲームパッド一つで操縦する方式を用意しました．
IsProControllerControlのチェックボックスを選択してください．
Proコントローラーで操縦することを想定して設定します．（今後別のゲームパッドでも問題なく操縦できるようにする予定です）

ジョイスティックのみを使用します．
デフォルトではクローラの操縦のみが行えます．
ZRボタンを押すことで操縦の方式が切り替わり，ジョイスティックで旋回，ブーム，アーム，バケットの操縦が行えるようになります．
再びZRボタンを押すと，クローラの操縦に切り替わります．

## ROSを使用する場合
ROS用のPCをもう一台用意する方法を説明します．
![image](https://github.com/user-attachments/assets/723fbe0b-af8b-41ca-adc4-f49d7a137f7a)

更新予定...


# 製作
早稲田大学　岩田浩康研究室　災害対応班  
山下侑輝　伊藤悠翔　岩田浩康  
お問い合わせ：cog-ml@iwata.mech.waseda.ac.jp

This simulator includes the work that is distributed in the Apache License 2.0.  
このシミュレータは、 Apache 2.0ライセンスで配布されている製作物が含まれています．



