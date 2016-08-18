using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;

namespace InterfaceLibrary.Editors
{
    [System.ComponentModel.DesignerCategory("")]
    public class RadioListBoxControl : CheckedListBoxControl
    {
        public RadioListBoxControl()
        {
            CheckOnClick = true;
            SelectionMode = System.Windows.Forms.SelectionMode.None;
        }

        protected override BaseControlPainter CreatePainter()
        {
            return new MyPainter();
        }

        protected override void SetItemCheckStateCore(int index, System.Windows.Forms.CheckState value)
        {
            if (value == System.Windows.Forms.CheckState.Checked)
                UnCheckAll();
            base.SetItemCheckStateCore(index, value);
        }
    }

    public class MyPainter : PainterCheckedListBox
    {
        public MyPainter() { }

        protected override void DrawItemCore(ControlGraphicsInfoArgs info, DevExpress.XtraEditors.ViewInfo.BaseListBoxViewInfo.ItemInfo itemInfo, DevExpress.XtraEditors.ListBoxDrawItemEventArgs e)
        {
            itemInfo.State = System.Windows.Forms.DrawItemState.None;
            ((DevExpress.XtraEditors.ViewInfo.CheckedListBoxViewInfo.CheckedItemInfo)(itemInfo)).CheckArgs.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            base.DrawItemCore(info, itemInfo, e);
        }
    }
}
