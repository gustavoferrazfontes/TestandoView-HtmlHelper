using NBehave.Spec.NUnit;
using NUnit.Framework;
using System.Web.Mvc;
using Web.Helpers;
using Web.ViewModel;
namespace Testandoview.Helpers.Test
{

    public class DadoUmHtmlHelperExtension : SpecBase
    {
        protected string expected;
        protected string actual;
        protected HtmlHelper htmlHelper;
        protected AcessoViewModel viewModel;
        protected override void Establish_context()
        {
            base.Establish_context();
            htmlHelper = new HtmlHelper(new ViewContext(), new ViewPage());
        }
    }

    public class QuandoStatusForDisponivel : DadoUmHtmlHelperExtension
    {


        protected override void Establish_context()
        {
            base.Establish_context();
            viewModel = new AcessoViewModel() { Status = "Disponivel" };
            expected = @"<div class='alert alert-success'>
                            <a href='http://gustavofontes.net'><i class='glyphicon glyphicon-ok'></i> Acesso Permitido</a>
                       </div>";
        }

        protected override void Because_of()
        {
            base.Because_of();

            actual = htmlHelper.PermissaoParaAcesso(viewModel).ToString();

        }
        [Test]
        public void EntaoDisponibilizoLinkDeAcesso()
        {
            actual.ShouldEqual(expected);
        }
    }

    public class QuandoStatusForBloqueado : DadoUmHtmlHelperExtension
    {

        protected override void Establish_context()
        {
            base.Establish_context();
            viewModel = new AcessoViewModel() { Status = "Bloqueado" };
            expected = @"<div class='alert alert-danger'>
                            <span><i class='glyphicon glyphicon-ban-circle'></i> Acesso Negado</span>
                        </div>";
        }

        protected override void Because_of()
        {
            base.Because_of();
            actual = htmlHelper.PermissaoParaAcesso(viewModel).ToString();
        }

        [Test]
        public void EntaoDisponibilizoAvisoDeAcessoNegado()
        {
            actual.ShouldEqual(expected);
        }
    }
}
