# スクリプトの設計書

各スクリプトの変数の受け渡しが複雑になってきたため、ここで全体の構成を整理する。

# 各スクリプトファイルの挙動

## システムスクリプト
### CursorArow
* カーソルとなるObjectの保存
* 十字キーによるCursorIndexの変動パターンの変更
* 決定ボタンの入力を取得
* CursorIndexをUIに紐づける
    * Indexが変わったら、カーソルを移動させる

### CursorMaster
* CursorArowの
”十字キーによるCursorIndexの変動パターンの変更”
の変更するパターンを指定する

### MenuAbstract
* cursorのMenuとなるために継承させる抽象クラス
* 自オブジェクトの画像の変換
* 決定ボタンを押した際の挙動を記述する抽象メソッドを設定

### MenuDataList
* CursorのmenuをDictonary<string,GameObject[]>として保存する
* Awakeで"home","charactorList"のMenuを登録する

### MemberSetting
* charactorListで選択したキャラクター名を保存するためのArray（nameArray）を設定
* Iconを選択した際に、そのIconのIndexとGameObjectを取得する
* charactorListを選択した際に、そのキャラクターのNameをnameArrayに保存
* Icon のname変数にも *↑* のデータを保存

## パーツとなるスクリプト
アタッチしたオブジェクトごとに変数の内容が違う。

### Icon : menuAbstrant
1. MemberSettingに自身のIndexとObjectを送信
2. cursorArowに次のカーソルとなるオブジェクトを送信
3. cursorMaterから、カーソルを変換するパターンをcharacterListに変換
4. cursorArowのIndexを初期化し、反映

### E_Icon : menuAbstract
現在、機能は未実装

### CharactorIcon : menuAbstract

# クラス図
## ノードの意味
<table>
<th>可視性</th><th>意味</th><th>効果</th>
<tr><td>＋</td><td>Public</td><td>パッケージ外からでも使える</td></tr>

<tr><td>ー</td><td>Private</td><td>そのクラス内でしか使えない</td></tr>

<tr><td>＃</td><td>Protected</td><td>親子関係同士のクラス両方</td></tr>

<tr><td>~</td><td>Package</td><td>パッケージ内ならどこでも使える</td></tr>
</table>

## 矢印の意味

|関係の種類|Mermaid|説明|
|--|--|--|
継承（Inheritanc）|	--> |あるクラス（子クラス）が別のクラス（親クラス）の属性や<br>操作（メソッド）を受け継ぐ関係|
実現（Realization）|..\|>	|クラスがインターフェースや抽象クラスで定義された操作を実装する関係<br>select()を実行したときに変化を及ぼすクラス|
合成（Composition）|--*	|全体-部分の強い結合。全体削除時、部分も削除される|
集約（Aggregation）|--o	|全体-部分の関係。部分は独立して存在可能。|
関連（Association）|-->	|クラス間の関連を表す。方向付き。|
リンク (Link)|--|単純な関連。実線で表現。|
依存（Dependency）|	..>	|クラスが別のクラスを使用する。疎結合。|

# 次やること
1. キャラクターを選択した際に、そのキャラクターを選択できないようにする
    1. 選択したキャラクターを取得（String）
    2. そのキャラクターを持っているCharactorIconを取得
    3. そのCharactorIconを識別する変数を追加(bool)
    4. そのBool変数を参照して、MenuDataListのaddMenu()



```mermaid
classDiagram

class MenuAbstract{
    - Image image
    + Sprit onImage
    + Sprit offImage
    - void Start()
    + void OnImage()
    + void OffImage()
    # void Select()
}
class CursorArow{
    - bool isUp
    - bool isDown
    - bool isLeft
    - bool isRight
    - GameObject startCursor
    - RectTransform cursorRect
    - CursorMaster cursorMaster
    + GameObject cursorObject
    + int cursorIndex
    + List &lt MenuAbstract &gt menuArray
    - void Start()
    - void switchingMethod()
    - void Updat()
    - void OnFire()
    - void homeCursor()
    - void charactorCursor()
    + void OnMove()
    + void UpdateCursor()
    + void UpdateMenu()
}
class CursorMaster{
    - MenuDataList menuDataList
    - CursorArow cursorArow
    + string moveKey
    - void Start()
    + void changeKey()
}

class CharactorIcon{
    - string myName
    - GameObject gm
    - CursorMater cursorMaster
    - CursorArow cursorArow
    + GameObject nextCursor
    + bool isDummy
    - void Start()
    # Void Select() 
}
class Icon{
    - GameObject nextCursor
    - GameObject gameMaster
    - CursorMaster cursorMaster
    - CursorArow cursorArow
    - MemberSetting membersetting
    + int myIndex
    + string selectedCharacterName
    - void Start()
    - void Update()
    # void Select()
}
class Submit{
    # void Select()
}
class E_Icon{
    + string enemyName
    - GameObject gm
    - EnemySetting enemySetting
    # void Select()
}
class MemberSetting{
    - int memberIndex
    + GameObject iconObj
    + string[] nemeArray
    + void setIndex(int nowIndex,GameObject nowObj)
    + void setCharactor(string selectName)
}
class EnemySetting{
    - MenuDataList menuDataList
    - GameObject[] windowObj
    - void Start():addMenu
    
}
class MenuDataList{
    - GameObject[] homeObj
    - GameObject[] charactorListObj
    + Dictionary &lt string,GameObject[] &gt menuStrage
    - void Awake()
    + void addMenu(string keyName , GameObject[] menu)
    + void updateCharactorMenu(string keyName)
}



MenuAbstract --> CharactorIcon
MenuAbstract --> Icon
MenuAbstract --> Submit
MenuAbstract --> E_Icon

Icon ..|> CursorMaster :changeKey("charactorList")
Icon ..|> CursorArow :UpdateCursor(nextCursor)
Icon ..|> CursorArow :cursorIndex = 0
Icon ..|> CursorArow :UpdateMenu()
Icon ..|> MemberSetting :setIndex(myIndex,gameObject)

CursorMaster *-- CursorArow :参照（moveKey)

CharactorIcon ..|> CursorArow :UpdateCursor(nextCursor)
CharactorIcon ..|> MemberSetting :setCharacter(myName)
CharactorIcon --o MemberSetting :select()
MemberSetting --o Icon :CharactorIcon.select()
Icon --o CharactorIcon :return(myIndex)
CharactorIcon ..|> CursorArow :cursorIndex = myIndex
CharactorIcon ..|> CursorMaster :chageKey("home")

CursorMaster -- MenuDataList
MenuDataList --|> MemberSetting :nameArrayを取得
MenuDataList --|> CharactorIcon :isDummyを判定

CursorArow ..|> MenuAbstract : do-select()

EnemySetting ..|> MenuDataList : Start()でaddMenu()をループで数回実行
```