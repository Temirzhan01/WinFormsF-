namespace MyWinForms

open System.Drawing
open System.Windows.Forms

module InitControls = 
    let standardButton = Size(100, 70)
    let plumpButton = Size(200,200)

    let tableLayoutPanel = 
        let tlp = new TableLayoutPanel()
        tlp.CellBorderStyle <- TableLayoutPanelCellBorderStyle.Single
        tlp.ColumnCount <- 2
        tlp.RowCount <- 2
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)) |> ignore
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)) |> ignore
        tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F)) |> ignore
        tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F)) |> ignore
        tlp.Dock <- DockStyle.Fill
        tlp.Name <- "tlp"
        tlp

    let button1 = 
        let btn = new Button()
        btn.Name <- "button1"
        btn.Size <- standardButton
        btn.TabIndex <- 0
        btn.Text <- "button1"
        btn.Anchor <- AnchorStyles.None
        btn.BackColor <- Color.BlueViolet
        btn

    let button2 = 
        let btn = new Button()
        btn.Name <- "button2"
        btn.Size <- standardButton
        btn.TabIndex <- 1
        btn.Text <- "button2"
        btn.Anchor <- AnchorStyles.None
        btn.BackColor <- Color.Chartreuse
        btn

    let button3 = 
        let btn = new Button()
        btn.Name <- "button3"
        btn.Size <- standardButton
        btn.TabIndex <- 2
        btn.Text <- "button3"
        btn.Anchor <- AnchorStyles.None
        btn.BackColor <- Color.CadetBlue
        btn

    let button4 = 
        let btn = new Button()
        btn.Name <- "button4"
        btn.Size <- standardButton
        btn.TabIndex <- 3
        btn.Text <- "button4"
        btn.Anchor <- AnchorStyles.None
        btn.BackColor <- Color.BurlyWood
        btn