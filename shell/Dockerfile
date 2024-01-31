# Use a lightweight base image
FROM ubuntu:latest

COPY hello.sh /

WORKDIR /

# Make the script executable
RUN chmod +x /hello.sh

# Run the Bash script when the container starts
ENTRYPOINT ["hello"]