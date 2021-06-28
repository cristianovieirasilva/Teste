namespace Classificados.Comum.Commands
{
    public interface ICommand
    {
        //utilizado para validar, gerando uma resposta, por vezes é o token
        public void Validar();
    }
}
