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

Run a Docker container (`run` starts a new container. For existing containers, see `start`)\
`docker run hello-docker`

Run the `ubuntu` Docker container in interactive mode\
`docker run -it ubuntu`

# Linux Commands

Show our currnet shell program\
`echo $0`

Print our current working directory: `pwd`

Listing contents of the working directory
- `ls` lists contents, typically on multiple lines
- `ls -1` lists contents in a one item per line
- `ls -l` long listing, incuding permissions

Managing directories (and files)
- `mkdir` to make a directory
- `mv` to "rename/move" a directory/file
- `rm` to remove a file.  To remove a directory, you might need `-r` for the recursive remove.

Managing files
- `touch` to interact with files.
- `touch file1.txt. file2.txt` can make multiple files.
- `cat` to concatenate, which is outputting the file's contents to the terminal. Good for small files.
- `more` to show the file contents in a way we can scroll.
  - Press Space to show next page. Press Enter to go line by line down. Press Q to exit.
- Install and use `less` to scroll up and down a file, much more interactive than `more`
- `head` and `tail` can show the first or last n lines of a file


Maintain packages with `apt` (advanced package tool)\
`apt list` to show packages\
`apt update` to update list of available packages
`apt install [name]` to install a package. It might not be in the list so `apt update` might be needed first.
