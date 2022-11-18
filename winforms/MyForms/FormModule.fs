namespace MyWinForms

open System.Drawing
open System.Windows.Forms

module FormModule = 
    type MyForm() =
        inherit Form()
        do
            base.Text <- "Windows Form F#"
            base.StartPosition <- FormStartPosition.CenterScreen
            base.Size <- new Size(800, 600)
            base.TopMost <- true

    // Создаем собственную форму.
    let myForm = new MyForm()

    // Приостановка работы макетов.
    // Приостановка актуальна при большом количестве визуальных элементов.
    // Уменьшает время визуализации формы.
    tableLayoutPanel.SuspendLayout()
    myForm.SuspendLayout()


    // Кнопки добавляются в контейнер TableLayoutPanel.
    tableLayoutPanel.Controls.Add(button1, 0, 0)
    tableLayoutPanel.Controls.Add(button2, 1, 0)
    tableLayoutPanel.Controls.Add(button3, 1, 1)
    tableLayoutPanel.Controls.Add(button4, 0, 1)
    tableLayoutPanel.Controls.Add(button4, 0, 1)

    // Код для исследования работы тандема методов 
    // SuspendLayout() - ResumeLayout()
    // Если раскомментировать данный код и
    // закомментировать вызовы SuspendLayout(), ResumeLayout(),
    // можно заметить задержку показа формы.
    // Если  только раскомментировать этот код 
    // визуализация формы происходит значительно быстрее.
    (* 
    for i = 0 to 2000 do
        let btn = new Button()
        btn.Name <- "button" + (i+10).ToString()
        btn.Size <- new Size(220, 120)
        btn.Text <- "button4"
        btn.Anchor <- AnchorStyles.None
        btn.Dock <- DockStyle.None
        tableLayoutPanel.Controls.Add(btn, 0, 1)
        *)

    // Добавляем таблицу на форму.
    myForm.Controls.Add(tableLayoutPanel)


    // Возобновляем работу макетов.
    tableLayoutPanel.ResumeLayout(false);
    myForm.ResumeLayout(false);

