FROM python:3.7-slim

RUN pip install --no-cache-dir boto3

WORKDIR /app

COPY . /app

CMD ["python", "basic.py"]