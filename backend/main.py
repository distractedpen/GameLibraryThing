from functools import lru_cache
import os
import uvicorn
from typing import Annotated
from fastapi import FastAPI, HTTPException, Depends, status
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel
from sqlalchemy.orm import Session

from database import engine, SessionLocal
from config import settings
import models


app = FastAPI(debug=True)
models.Base.metadata.create_all(bind=engine)

origins = [
    "*",
]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


class GameBase(BaseModel):
    name: str
    developer: str
    status: str


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


db_dependency = Annotated[Session, Depends(get_db)]


@app.post("/api/games/", status_code=status.HTTP_201_CREATED)
async def create_game(game: GameBase, db: db_dependency):
    db_game = models.Game(**game.model_dump())
    db.add(db_game)
    db.commit()


@app.get("/api/games/{game_id}", status_code=status.HTTP_200_OK)
async def get_games(game_id: int, db: db_dependency):
    game = db.query(models.Game).filter(models.Game.id == game_id).first()
    if game is None:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND)
    return game


@app.get("/api/games/", status_code=status.HTTP_200_OK)
async def get_all_games(db: db_dependency):
    games = db.query(models.Game).all()
    return games


@app.put("/api/games/{game_id}", status_code=status.HTTP_200_OK)
async def update_game(game_id: int, new_game: GameBase, db: db_dependency):
    old_game = db.query(models.Game).filter(models.Game.id == game_id).first()
    if old_game is None:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND)
    db.delete(old_game)
    db_new_game = models.Game(**new_game.model_dump())
    db.add(db_new_game)
    db.commit()

@app.delete("/api/games/{game_id}", status_code=status.HTTP_200_OK)
async def delete_game(game_id: int, db:db_dependency):
    old_game = db.query(models.Game).filter(models.Game.id == game_id).first()
    if old_game is None:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND)
    db.delete(old_game)
    db.commit()



if __name__ == '__main__':
    uvicorn.run(app, host=settings.api_host, port=settings.api_port, log_level="info")
