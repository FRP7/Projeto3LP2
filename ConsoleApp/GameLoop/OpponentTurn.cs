using System;
using System.Collections.Generic;
using Common;

namespace ConsoleApp
{
    public class OpponentTurn
    {
        private GameState gameState = new GameState();

        public List<Tuple<int, SlotTypes, SlotColors>> GetPlayerLegalPlays
        {
            get => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
            set => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
        }

        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
        {
            get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
            set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        }

        public void OpponentPlay(int piece, int slot)
        {

            if (ChoosePiece(piece, slot))
            {
                if (CheckIfLegal(piece, slot))
                {
                    PlayPiece(piece, slot);
                }
                else
                {
                    // a jogada não é válida
                }
            }
            else
            {
                // a peça ou a slot não existem
            }
        }

        private bool ChoosePiece(int piece, int slot)
        {
            gameState.CheckOpponentLegalPlays(piece);

            return true;
        }

        private bool CheckIfLegal(int piece, int slot)
        {
            return gameState.CheckIfLegal(piece, slot);
        }

        private void PlayPiece(int piece, int slot)
        {
            if (GameLoop.IsPlayerWhite)
            {
                gameState.OpponentPlay(piece, slot, true);
            }
            else
            {
                gameState.OpponentPlay(piece, slot, false);
            }
        }
    }
}

