FROM node:16-alpine3.15 AS build

RUN yarn global add pm2

WORKDIR /src

COPY . .

RUN yarn
RUN yarn build

EXPOSE 3000
ENV API_URL=http://localhost:6062

CMD [ "pm2-runtime", "start", "npm", "--", "start" ]
