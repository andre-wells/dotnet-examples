# Docker Cheat Sheet


# Docker Commands

Build a docker image using the file in the path `.`. The `-t` means tag; we're giving this image a name.\
`docker build -t hello-docker` .

Show list of images\
`docker image ls`

Show list of containers\
`docker ps`

Show list of all containers, even if they're not running\
`docker ps -a`

Run a Docker container\
`docker run hello-docker`

Run the `ubuntu` Docker container in interactive mode\
`docker run -it ubuntu`

# Linux Commands

Show our currnet shell program\
`echo $0`

Maintain packages with `apt` (advanced package tool)\
`apt list` to show packages\
`apt update` to update list of available packages
`apt install [name]` to install a package. It might not be in the list so `apt update` might be needed first.
