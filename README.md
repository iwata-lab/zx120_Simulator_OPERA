# Simulator on Unity + PhysX communicating with ROS
# Simulator on Unity + PhysX communicating with ROS

これは,Unity と PhysX を使用し,ROS と通信する建設機械シミュレータです.

## 概要

このシミュレータは,[土木研究所](https://www.pwri.go.jp/)が提供する[OPERA（Open Platform for Engineering Resources of Applications）](https://github.com/PWRIEarthquakeLab/OPERA)をベースにしています.OPERAは,建設機械の自動化・自律化のための研究開発プラットフォームだよ.

- OPERA GitHubリポジトリ: [https://github.com/PWRIEarthquakeLab/OPERA](https://github.com/PWRIEarthquakeLab/OPERA)
- OPERAについての詳細: [https://www.pwri.go.jp/team/advanced-technology/jp/about/opera.html](https://www.pwri.go.jp/team/advanced-technology/jp/about/opera.html)

## 特徴

もとのリンク見てください．けどすごい完成度油圧ショベルのモデルが使えます．

## カスタムステージ

操作の練習用に簡単にステージを改造しました：

![image](https://github.com/Yamayou-Omiya/OperaSimulatorrrrr/assets/173669614/8846db1d-8399-4c23-94be-a0dc5ceebce4)

## 油圧ショベルの操作

油圧ショベルをキーボード操作で行えるように簡単に改造を行いました．

- I/K: ブーム上下
- E/D: スイング左右
- F/A: アーム伸縮
- J/L: バケット開閉
- T/G: 左クローラ前進，後退
- Y/H: 右クローラ前進，後退

方式は縦旋回をイメージしました
![image](https://github.com/Yamayou-Omiya/OperaSimulatorrrrr/assets/173669614/82728ad8-3ff0-4d1f-b283-276f3b00587d)

## 使い方
キーボードで操作したければContorollerWithKeyboardのMypublisher.csを有効にしてください，使いたくなければ無効にしてください．
![image](https://github.com/Yamayou-Omiya/OperaSimulatorrrrr/assets/173669614/a162d869-1bbe-4e89-83d6-d5698d272ae8)