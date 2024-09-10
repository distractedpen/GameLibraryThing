from pydantic_settings import BaseSettings, SettingsConfigDict


class Settings(BaseSettings):
    db_protocol: str
    db_user: str
    db_password: str
    db_host: str
    db_port: int
    db_name: str
    api_host: str
    api_port: int

    model_config = SettingsConfigDict(env_file="../.env", env_prefix="PY_", extra="ignore")


settings = Settings()
