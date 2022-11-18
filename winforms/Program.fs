open System
open System.Drawing
open System.IO
open System.Windows.Forms

Application.EnableVisualStyles()
Application.SetCompatibleTextRenderingDefault(false)

let form = new Form(Width = 850,Text = "Main", StartPosition = FormStartPosition.CenterScreen)

let menu = MenuStrip()

let ex2 = new ToolStripMenuItem("Квадратное уровнение")
let ex3 = new ToolStripMenuItem("Вычисление")
let ex4 = new ToolStripMenuItem("Рисунок")
let ex5 = new ToolStripMenuItem("Время года")
let ex6 = new ToolStripMenuItem("Ползунок")
let ex7 = new ToolStripMenuItem("Флажки")
let ex8 = new ToolStripMenuItem("Список")
let ex9 = new ToolStripMenuItem("Индикатор")
let ex10 = new ToolStripMenuItem("Площадь прямоугольника")

menu.Items.Add(ex2)
menu.Items.Add(ex3)
menu.Items.Add(ex4)
menu.Items.Add(ex5)
menu.Items.Add(ex6)
menu.Items.Add(ex7)
menu.Items.Add(ex8)
menu.Items.Add(ex9)
menu.Items.Add(ex10)

form.Controls.Add(menu)

let form2 = new Form(Width = 400, Height = 400, Text = "Квадратное уровнение", StartPosition = FormStartPosition.CenterScreen)
let a = new TextBox(Text="5");
form2.Controls.Add(a);
let b = new TextBox(Text="-7",Top=20);
form2.Controls.Add(b);
let c = new TextBox(Text="2",Top=40);
form2.Controls.Add(c);
let answer = new Button(Text="Answer",Top=70,Width=90,Height=25)
form2.Controls.Add(answer)
let result = RichTextBox(Text = "",Top = 100, Height = 50)
form2.Controls.Add(result)
let answer_Click(sender:System.Object) (e:System.EventArgs) : unit =
    let button: Button = sender :?> Button
    let discriminant = Math.Sqrt(((float(b.Text))*(Double.Parse(b.Text))) - (4.0*Double.Parse(a.Text)*Double.Parse(c.Text))) 
    let x1 = (-Double.Parse(b.Text)+discriminant)/(2.0*Double.Parse(a.Text));
    let x2 = (-Double.Parse(b.Text)-discriminant)/(2.0*Double.Parse(a.Text));
    result.Text <- ($"x1 = {x1} \nx2 = {x2}")
answer.Click.AddHandler(answer_Click)

let form3 = new Form(Width = 400, Height = 400, Text = "Вычисление", StartPosition = FormStartPosition.CenterScreen)
let first = new TextBox(Text="0");
form3.Controls.Add(first);
let second = new TextBox(Text="0",Top=20);
form3.Controls.Add(second);
let l1 = new Button(Text="+",Top=50,Width=25,Height=25);
let l2 = new Button(Text="-",Top=50,Width=25,Height=25,Left=30);
let l3 = new Button(Text="/",Top=50,Width=25,Height=25,Left=60);
let l4 = new Button(Text="*",Top=50,Width=25,Height=25,Left=90);
form3.Controls.Add(l1)
form3.Controls.Add(l2)
form3.Controls.Add(l3)
form3.Controls.Add(l4)
let sum _= MessageBox.Show($"{first.Text} + {second.Text} = {Double.Parse(first.Text) + Double.Parse(second.Text)}","Answer") |>ignore
let _= l1.Click.Add(sum);
let minus _= MessageBox.Show($"{first.Text} - {second.Text} = {Double.Parse(first.Text) - Double.Parse(second.Text)}","Answer") |>ignore
let _= l2.Click.Add(minus);
let mutable st = "error"
let mutable st2 = "error"
let delit _= MessageBox.Show($"{first.Text} / {second.Text} = {
    if( Double.Parse(second.Text) <> 0 ) then
        st <- string(Double.Parse(first.Text) / Double.Parse(second.Text))
    else
    st <- st2 } {st}","Answer")|>ignore 
let _= l3.Click.Add(delit)
let multiply _= MessageBox.Show($"{first.Text} * {second.Text} = {Double.Parse(first.Text) * Double.Parse(second.Text)}","Answer") |>ignore
let _= l4.Click.Add(multiply);

let form4 = new Form(Width = 800, Height = 580, Text = "Рисунок", StartPosition = FormStartPosition.CenterScreen)
let btform4 = new Button(Text="Swap to 2",Top=500,Width=100,Height=25,Left=330);
let Pic1= new PictureBox(SizeMode=PictureBoxSizeMode.StretchImage,Top=5,Left=20, Size = new Size(720, 480))
Pic1.ImageLocation <- @"C:\Users\cross\Source\Repos\winforms\1.jpg"
form4.Controls.Add(Pic1)
form4.Controls.Add(btform4)
let swap_Click(sender:System.Object) (e:System.EventArgs) : unit =
    let button: Button = sender :?> Button
    let path = @"C:\Users\cross\Source\Repos\winforms\1.jpg"
    let path2 = @"C:\Users\cross\Source\Repos\winforms\2.jpg"
    if (btform4.Text = "Swap to 2") then 
    Pic1.ImageLocation <- path2
    btform4.Text <- "Swap to 1"
    else 
    Pic1.ImageLocation <- path
    btform4.Text <- "Swap to 2"
btform4.Click.AddHandler(swap_Click)


let form5 = new Form(Width = 400, Height = 400, Text = "Время года", StartPosition = FormStartPosition.CenterScreen)
let Cal = new MonthCalendar()
let btform5 = new Button(Dock=DockStyle.Bottom,Text="select")
form5.Controls.Add(Cal)
form5.Controls.Add(btform5)
let mutable season = ""
let season_Click(sender:System.Object) (e:System.EventArgs) : unit =
    let button: Button = sender :?> Button
    if(Cal.SelectionStart.Month >= 0 && Cal.SelectionStart.Month < 3 || Cal.SelectionStart.Month = 12) then season <- "зима"
    if(Cal.SelectionStart.Month > 2 && Cal.SelectionStart.Month < 6) then season <- "весна"
    if(Cal.SelectionStart.Month > 6 && Cal.SelectionStart.Month < 9) then season <- "лето"
    if(Cal.SelectionStart.Month > 9 && Cal.SelectionStart.Month < 12) then season <- "осень"
btform5.Click.AddHandler(season_Click)
let MsgDay _= MessageBox.Show("Сейчас "+season) |>ignore
let _= btform5.Click.Add(MsgDay);


let form6 = new Form(Width = 400, Height = 400, Text = "Ползунок", StartPosition = FormStartPosition.CenterScreen)
let progressbar= new ProgressBar(Dock = DockStyle.Top)
let btform6 = new Button(Text="Текст кнопки",Top=10,Width=100,Height=25,Left=50,BackColor=Color.Gold);
let scrollbar= new TrackBar(Top=150,Left=50 ,Maximum=200,Width=300)
form6.Controls.Add(scrollbar)
form6.Controls.Add(btform6)
let ChangeButton _= btform6.Width<-scrollbar.Value
let _=scrollbar.ValueChanged.Add(ChangeButton)

let form7 = new Form(Width = 400, Height = 400, Text = "Флажки", StartPosition = FormStartPosition.CenterScreen)
let btform7 = new Button(Text="какие флажки отмечены",Top=200,Width=100,Height=55,Left=150,BackColor=Color.Bisque);
let checkbox71= new CheckBox(Text="first",Top=50,Width=100,Height=50,Left=50)
let checkbox72= new CheckBox(Text="second",Top=100,Width=100,Height=50,Left=50)
let mutable st7="не отмечен ни один из флажков"
let st71="отмечен первый флажок"
let st72="отмечен второй флажок"
let st73="отмечены оба флажка"
let st74="не отмечен ни один из флажков"
form7.Controls.Add(btform7)
form7.Controls.Add(checkbox71)
form7.Controls.Add(checkbox72)
let otvet7 _= MessageBox.Show($"{
    if(checkbox71.Checked=true && checkbox72.Checked=false) then
    st7 <- st71
    elif(checkbox71.Checked=false && checkbox72.Checked=true) then 
    st7 <- st72
    elif(checkbox71.Checked=true && checkbox72.Checked=true) then 
    st7 <- st73
    else
    st7 <- st74
    } {st7}","Answer") |>ignore
let _=btform7.Click.Add(otvet7);

let form8 = new Form(Width = 400, Height = 400, Text = "Список", StartPosition = FormStartPosition.CenterScreen)
let btform8 = new Button(Text="добавить",Top=60,Width=100,Height=55,Left=150,BackColor=Color.AliceBlue);
let text8 = new TextBox(Text="Текст",Top=30,Width=100,Height=55,Left=150)
form8.Controls.Add(text8);
form8.Controls.Add(btform8);
let list8 = new ListBox(Text="Список",Top=120,Width=100,Height=100,Left=150)
let cars = ("вещь");
list8.Items.Add("объект");
list8.Items.Add("субъект");
form8.Controls.Add(list8);
let bt8 _= list8.Items.Add(string(text8.Text)) |>ignore
let _= btform8.Click.Add(bt8)

let form9 = new Form(Width = 400, Height = 400, Text = "Индикатор", StartPosition = FormStartPosition.CenterScreen)
let text9 = new TextBox(Text="qq",Top=30,Width=300,Height=105,Left=50, MaxLength = 100)
let progress9 = new ProgressBar(Top=150,Width=300,Height=60,Value=text9.TextLength,Left=50,Minimum=0,Maximum=100,Step=1)
let btform9 = new Button(Text="добавить",Top=220,Width=100,Height=55,Left=150,BackColor=Color.Beige);
let Changeprogress9 _= progress9.Value <- text9.TextLength
let _= text9.TextChanged.Add(Changeprogress9)
form9.Controls.Add(text9);
form9.Controls.Add(progress9);

let form10 = new Form(Width = 400, Height = 400, Text = "Площадь прямоугольника", StartPosition = FormStartPosition.CenterScreen)
let aa = new TextBox(Text="5",Top=20);
form10.Controls.Add(aa);
let bb = new TextBox(Text="6",Top=40);
form10.Controls.Add(bb);
let ans=new Button(Text="Answer",Top=70,Width=25,Height=25)
form10.Controls.Add(ans)
let ploshad _= MessageBox.Show($"{Double.Parse(aa.Text)*Double.Parse(bb.Text)}","Answer") |>ignore
let _=ans.Click.Add(ploshad);

let opForm2 _= do form2.ShowDialog()
let _= ex2.Click.Add(opForm2);
let opForm3 _= do form3.ShowDialog()
let _= ex3.Click.Add(opForm3);
let opForm4 _= do form4.ShowDialog()
let _= ex4.Click.Add(opForm4);
let opForm5 _= do form5.ShowDialog()
let _= ex5.Click.Add(opForm5);
let opForm6 _= do form6.ShowDialog()
let _= ex6.Click.Add(opForm6);
let opForm7 _= do form7.ShowDialog()
let _= ex7.Click.Add(opForm7);
let opForm8 _= do form8.ShowDialog()
let _= ex8.Click.Add(opForm8);
let opForm9 _= do form9.ShowDialog()
let _= ex9.Click.Add(opForm9);
let opForm10 _= do form10.ShowDialog()
let _= ex10.Click.Add(opForm10);

Application.Run(form)