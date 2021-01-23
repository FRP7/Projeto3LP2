using System;
using System.Collections.Generic;
using Common;

namespace ConsoleApp
{
    public class PlayerTurn
    {
        private GameState gameState = new GameState();

        public List<Tuple<int, SlotTypes, SlotColors, bool>> GetPlayerLegalPlays
        {
            get => ServiceLocator.GetService<GameState>().PlayerLegalPlays;
            set => ServiceLocator.GetService<GameState>().PlayerLegalPlays = value;
        }

        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
        {
            get => ServiceLocator.GetService<GameState>().AllSlots;
            set => ServiceLocator.GetService<GameState>().AllSlots = value;
        }

        public bool IsPlayed { get; set; }

        public void PlayerPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (ChoosePiece(piece, slot))
            {
                if (CheckIfLegal(piece, slot))
                {
                    PlayPiece(piece, slot, isPlayerWhite);
                    IsPlayed = true;
                }
            }
        }

        private bool ChoosePiece(int piece, int slot)
        {
            gameState.CheckPlayerLegalPlays(piece);

            return true;
        }

        private bool CheckIfLegal(int piece, int slot)
        {
            return gameState.CheckIfLegal(piece, slot);
        }

        private void PlayPiece(int piece, int slot, bool isPlayerWhite)
        {
            if (isPlayerWhite)
            {
                gameState.PlayerPlay(piece, slot, true);
            }
            else
            {
                gameState.PlayerPlay(piece, slot, false);
            }
        }

        public PlayerTurn()
        {
            IsPlayed = false;
        }
    }
}
