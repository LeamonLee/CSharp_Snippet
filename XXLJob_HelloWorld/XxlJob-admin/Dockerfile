FROM openjdk:8-jre-slim
MAINTAINER xuxueli

ENV PARAMS="--spring.datasource.url=jdbc:postgresql://172.21.160.15:5432/c1e2928f-0e17-42d9-8d8d-5e67cc9e9fd0?Unicode=true&characterEncoding=UTF-8 --spring.datasource.username=16eb5838-d57a-4437-9e7f-898c1f655e20 --spring.datasource.password=KMQJcZVBmoD6tmfAOOa2IjBb9 --spring.datasource.driver-class-name=org.postgresql.Driver"

ENV TZ=PRC
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

ADD target/xxl-job-admin-*.jar /app.jar

ENTRYPOINT ["sh","-c","java -jar $JAVA_OPTS /app.jar $PARAMS"]