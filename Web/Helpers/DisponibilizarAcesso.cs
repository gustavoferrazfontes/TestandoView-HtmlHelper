using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Helpers
{
    public static class DisponibilizarAcesso
    {
        public static MvcHtmlString PermissaoParaAcesso(this HtmlHelper htmlHelper, AcessoViewModel model)
        {

            string html = string.Empty;
            if (model != null)
            {
                if (model.Status == "Disponivel")
                {
                    html = @"<div class='alert alert-success'>
                            <a href='http://gustavofontes.net'><i class='glyphicon glyphicon-ok'></i> Acesso Permitido</a>
                       </div>";
                }
                else if (model.Status == "Bloqueado")
                {
                    html = @"<div class='alert alert-danger'>
                            <span><i class='glyphicon glyphicon-ban-circle'></i> Acesso Negado</span>
                        </div>";
                }

            }
            return MvcHtmlString.Create(html);
        }
    }
}