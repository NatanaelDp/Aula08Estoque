namespace Aula08Estoque
{
    public partial class Form1 : Form
    {
        //Variáveis globais
        public  List<string>produtoNome= new List<string>();    
        public  List<int> produtoQuantidade= new List<int>();
        Utilidades utilidades = new Utilidades();
        public Form1()
        {
            InitializeComponent();
        }
        //funções...
        void adicionaProduto()
        {
            if (utilidades.textBoxEstaVazio(txtNome)==true)
            {
                MessageBox.Show("O nome está vazio");
                return;
            }
            if(utilidades.textBoxEstaVazio(txtQuantidade)==true)
            {
                MessageBox.Show("Quantidade está vazia!");
                return;
            }
            
            string nome=txtNome.Text;
            int quantidade=int.Parse(txtQuantidade.Text);
            produtoNome.Add(nome);  
            produtoQuantidade.Add(quantidade);
        }

        void atualizaInterface()
        {
            //contabiliza a quantidade cadastrada
            int quantidade_cadastrada=produtoNome.Count();
            lblCadastrados.Text = quantidade_cadastrada.ToString();

            //contabiliza todos os produtos em estoque
            //For:a variável controladora; condição ; incrementar o contador
            int estoque = 0;
            for (int i =0;i <produtoQuantidade.Count; i++ )
            {
                int quantidade = produtoQuantidade[i];
                estoque += quantidade;
            }
            lblQuantidade.Text = estoque.ToString();
        }
        void limpaCampos()
        {
            //txtNome.Text="";
            //txtQuantidade.Text="";
            txtNome.Clear();
            txtQuantidade.Text = "";
            txtNome.Focus();
        }
        void verProduto(bool primeiro)
        {

            if (listaEstaVazia()==true)
            {
                MessageBox.Show("Você não pode ver a  lista ainda... ");
                return;
            }

            string nome;
            int quantidade;
            if (primeiro == true)
            {
                nome = produtoNome[0];
                quantidade= produtoQuantidade[0];
            }   
            else
            {
                nome = produtoNome[produtoNome.Count()-1];
                quantidade = produtoQuantidade[produtoQuantidade.Count()-1];
            }


            MessageBox.Show($"Nome: {nome} , Quantidade : {quantidade} ");
        }
        void removerProduto()
        {
            if (listaEstaVazia()==true)
            {
                MessageBox.Show("Você não pode remover");
            }
            else
            {
                produtoNome.RemoveAt(0);
                produtoQuantidade.RemoveAt(0);
                atualizaInterface();
            }
            
        }
        bool listaEstaVazia()
        {
            if (produtoNome.Count()>0)
            {
                return (false);

            }
            else
            {
                return(true);
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            adicionaProduto();
            atualizaInterface();
            limpaCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void btnVerPrimeiro_Click(object sender, EventArgs e)
        {
            verProduto(true);
        }

        private void btnVerUltimo_Click(object sender, EventArgs e)
        {
            verProduto(false);
        }

        private void btnDeletarPimeiro_Click(object sender, EventArgs e)
        {
            removerProduto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilidades utilidades= new Utilidades();
            utilidades.mostraMensagem();
        }
    }
}