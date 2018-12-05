echo Killing Website
tmux kill-session -t website

echo Killing Server
tmux kill-session -t server

if ! [ -n "$1" ]; then
    echo Pulling
    git pull
fi

echo Running Server
tmux new -d -s website 'sudo dotnet run --project ./Website'

echo Running Server
tmux new -d -s server 'sudo dotnet run --project ./Server'