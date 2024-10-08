/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_APP_API_HOST: string;
    readonly VITE_APP_API_PORT: int;
}

interface ImportMeta {
    readonly env: ImportMetaEnv;
}