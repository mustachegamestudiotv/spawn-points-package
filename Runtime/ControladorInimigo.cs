using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MustacheGameStudioTV.SpawnPoints {

    [System.Serializable]
    public class ControladorInimigo {

        [SerializeField]
        private OndaInimigo[] ondasInimigo;


        private int indiceOndaInimigoAtual;
        private OndaInimigo ondaInimigoAtual;


        public void Iniciar() {
            this.indiceOndaInimigoAtual = 0;
            this.ondaInimigoAtual = this.ondasInimigo[this.indiceOndaInimigoAtual];
            this.ondaInimigoAtual.Iniciar();
        }

        public void Atualizar() {
            if (this.ondaInimigoAtual == null) {
                return;
            }

            this.ondaInimigoAtual.Atualizar();
            if (this.ondaInimigoAtual.Finalizada) {
                AvancarParaProximaOndaInimigo();
            }
        }

        private void AvancarParaProximaOndaInimigo() {
            // Existe uma próxima onda?
            if (this.indiceOndaInimigoAtual < (this.ondasInimigo.Length - 1)) {
                // Avança para a próxima onda
                this.indiceOndaInimigoAtual++;
                this.ondaInimigoAtual = this.ondasInimigo[this.indiceOndaInimigoAtual];
                this.ondaInimigoAtual.Iniciar();
            } else {
                this.ondaInimigoAtual = null;
            }
        }

    }

}