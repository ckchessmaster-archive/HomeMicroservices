FROM node:10.4.0-alpine

WORKDIR /app
COPY package*.json ./
npm install

npm run dev
