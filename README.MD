## Unity CakeBehaviour v2 (on developing)
#### *features:*
- 完成CakeBehaviour的雛型，並應用於CakeBehaviourExample.cs。由於
更改到基層設計，目前MBCakeExample不能用了。
- 取消Slice相加的功能，MBSlice變成cache MBCake並修改的輔助性類別。宣告`MBSlice MyFlow() => Add.Awake(...).Start(...);` Slice會在執行`MyFlow()`時直接加載至MBCake;
- 解決了無法使用非靜態欄位的問題。現在除了設計MonoBehaviou行為的方式，應該都和一般開發MonoBehaviour一樣。
- 但也可以使用原本的設計模式，和UIBehaviour的宣告方式一樣: `protected override void ...()`。
- 解決了lambda表達式`()=> obj = new GameObject()`的問題

#### *ToDo:*
- [ ] 場景存在多個CakeBehaviour是否互相干擾的測試
- [ ] `return END`的應用的測試
- [ ] 效能優化的檢查

#### *Ideas:*
- 如果除了加載Slice，還能拆卸Slice好像滿猛的...🤔
- 執行時動態加裝/拆卸Slice? 做到的話，應該能實現CakeBehaviour用於設計更精細的物件行為。
- 好，我放棄回傳值多載。想要減少宣告時使用下括號，但是property不能有多型別、選擇性參數不能有重複名稱，只有method可以在同名的情況下接受`Action`或`Func<bool>`......就寄望Microsoft未來更新時拓展語法吧。