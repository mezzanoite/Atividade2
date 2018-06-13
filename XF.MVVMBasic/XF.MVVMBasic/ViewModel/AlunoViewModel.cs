using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.View;

namespace XF.MVVMBasic.ViewModel
{

    public class AlunoViewModel
    {

        public INavigation Navigation;

        public ICommand TelaAlunoCommand { get; set; }
        public ICommand CadastrarAlunoCommand { get; set; }

        public Aluno Aluno { get; set; }

        private ObservableCollection<Aluno> listaAlunos;
        public ObservableCollection<Aluno> ListaAlunos
        {
            get { return listaAlunos; }
            set { listaAlunos = value; }
        }

        #region Propriedades
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        #endregion
        public AlunoViewModel()
        {
            ListaAlunos = new ObservableCollection<Aluno>()
            {
                new Aluno()
                {
                    Id = Guid.NewGuid(),
                    RM = "1234567",
                    Nome = "Aluno de Teste 1",
                    Email = "alunoteste1@teste.com"
                },
                new Aluno()
                {
                    Id = Guid.NewGuid(),
                    RM = "7654321",
                    Nome = "Aluno de Teste 2",
                    Email = "alunoteste2@teste.com"
                }
            };
            TelaAlunoCommand = new Command(OnNovoAlunoClicked);
            CadastrarAlunoCommand = new Command(OnCadastrarAlunoClicked);
        }

        public void AdicionarAluno(Aluno aluno)
        {
            aluno.Id = Guid.NewGuid();
            this.listaAlunos.Add(aluno);
        }

        private void OnNovoAlunoClicked(object obj)
        {
            this.Aluno = new Aluno();
            Navigation.PushAsync(new NovoAlunoView() { BindingContext = this });
        }

        private void OnCadastrarAlunoClicked(object obj)
        {
            var senderAluno = obj as Aluno;
            this.AdicionarAluno(senderAluno);
            Navigation.PopAsync();
        }
    }
}
