using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public int QntPessoas { get; set; }
        public string Tema { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedeSociais { get; set; }
        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}