using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>(); //going to store 2 players
    public Player currentActivePlayer; //current player's turn

    public BoardPiece[,] BoardMap = new BoardPiece[3, 3]; //2D Array
    public CanvasManager canvasManager;

    // Start is called before the first frame update
    void Start()
    {
        //--temp code
        players.Add(new Player() { id = Player.Id.Player1, nickname = "P1", assignedFruit = Fruit.FruitType.Apple });
        players.Add(new Player() { id = Player.Id.Player2, nickname = "P2", assignedFruit = Fruit.FruitType.Strawberry });
        //-end temp code

        ChangeActivePlayer();
    }

    public void ChangeActivePlayer()
    {
        if(currentActivePlayer == null)
        {
            currentActivePlayer = players.Find(x => x.id == Player.Id.Player1);//by default set player1 as active player
        }
        else if(currentActivePlayer.id == Player.Id.Player1)
        {
            currentActivePlayer = players.Find(x => x.id == Player.Id.Player2);
        }
        else if(currentActivePlayer.id == Player.Id.Player2)
        {
            currentActivePlayer = players.Find(x => x.id == Player.Id.Player1);
        }

        //notify canvasmanager that player is changed
        canvasManager.ChangeBottomLabel("Player Turn:" + currentActivePlayer.nickname);
    }

    //called when the player clicks on one of the board pieces ex:Loc0-0
    public void SelectBoardPiece(GameObject gameObjBoardPiece)
    {
        BoardPiece boardPiece = gameObjBoardPiece.GetComponent<BoardPiece>();

        if(boardPiece.GetFruit() == Fruit.FruitType.None)
        {
            //set fruit according to current active player
            boardPiece.SetFruit(currentActivePlayer.assignedFruit);

            //update boardMap
            BoardMap[boardPiece.row, boardPiece.column] = boardPiece;

            //notify the canvas manager to render/update board
            canvasManager.BoardPaint(gameObjBoardPiece);

            //change active player
            ChangeActivePlayer();
        }
    }

    private bool IsGameDraw()
    {
        foreach(BoardPiece boardPiece in BoardMap)
        {
            if (boardPiece == null)
                return false;
        }

        return true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
