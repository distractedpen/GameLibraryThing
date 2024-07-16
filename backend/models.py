from sqlalchemy import Column, Integer, String
from database import Base


class Game(Base):
    __tablename__ = "games"

    id = Column(Integer, primary_key=True, index=True)
    name = Column(String(50))
    developer = Column(String(50))
    status = Column(String(50))  # TODO: Convert to an Enum ["Want", "Own", "Playing", "Paused", "Completed", "Dropped"]