# Game Library Thing (Name subject to Change)

Personal Game Library Manager. Track the games you own/want and if you have completed them.

# Dev Setup
Requirements:
- Python 3.12
- NodeJS

Rename `.env.sample` to `.env` file in root dir.  

For backend:  
`python3 -m venv .venv` in backend dir  
`pip install -r requirements.txt`

Postgresql is currently assumed to be your database. `psycopg2-binary` is listed in requirements.txt. If you wish to use another database, remove this dep.


For frontend:  
`npm i` in frontend dir  
`npm run dev`
