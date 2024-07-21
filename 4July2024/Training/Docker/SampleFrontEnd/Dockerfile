FROM node:20-alpine

WORKDIR /app

RUN npm install -g nodemon

COPY . /app

RUN npm install

EXPOSE 3232

CMD ["npm", "run","dev"]
