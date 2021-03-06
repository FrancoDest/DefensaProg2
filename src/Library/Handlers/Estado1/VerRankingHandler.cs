using Telegram.Bot.Types;
using System.Collections.Generic;
using System.Text;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerRanking".
    /// </summary>
    public class VerRankingHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "VerRanking".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public VerRankingHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VerRanking"};
        }

        /// <summary>
        /// Procesa el mensaje "VerRanking" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            try
            {
                respuesta = string.Empty;
                if (this.CanHandle(mensaje))
                {
                    respuesta = "Este es el ranking donde están los jugadores con sus posiciones, dependiendo de sus partidas ganadas y perdidas:\n";

                    respuesta += Planificador.VerRanking();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                respuesta = "Ha ocurrido un error. Intente de nuevo \n";
                return true;
            }
        }
    }
}
