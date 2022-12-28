using IronPython.Hosting;

namespace WinFormsIronPythonExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();

            //You can also load script from file
            var source = engine.CreateScriptSourceFromFile(
                Path.Combine(Application.StartupPath, "Code.py"));

            //You can load from string
            //var source = engine.CreateScriptSourceFromString(
            //    "def hello(name):" + "\n" +
            //    "    result = 'Hello, {}!'.format(name)" + "\n" +
            //    "    return(result)",
            //    Microsoft.Scripting.SourceCodeKind.Statements);

            var compiled = source.Compile();
            compiled.Execute(scope);
            dynamic hello = scope.GetVariable("hello");
            var result = hello(textBox1.Text);
            MessageBox.Show((string)result);
        }
    }
}