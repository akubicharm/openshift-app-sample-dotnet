# DotNetのサンプルアプリ

## TodoApp

＜図を入れる＞

### BlazorTodo
TodoアプリケーションのUI。

### TodoApi
Todoアプリケーションのバックエンドアプリケーション。TodoアイテムのCRUD処理を行います。

### デプロイ方法

`todoapp` というOpenShiftのプロジェクトにPostgresqlとフロントアプリとバックエンドアプリをデプロイして行きます。

#### データベースの準備

■ データベースのデプロイ

PostgresqlをOpenShiftにデプロイします。
OpenShiftのポータルからデプロイする場合は、開発者カタログからPostgresqlを選択してデプロイします。

|名前|値|
|---|---|
|Database Service Name|postgresql|
|PostgreSQL Connection Username|postgres|
|Postgresql Connection Password|postgres|

■ データベースとテーブルの作成

Postgresqlのコンテナに rsh で接続します。
```
oc rsh service/postgresql
```

Postgresqlにpostgresqlユーザでログインして、`todoapp`データベースを作成します。
```
psql -U postgresql

# Postgresqlのプロンプトになる
postgres=# create database todoapp;

# todoappデータベースに接続
postgres=# \c todoapp
todoapp=# create table todo (id serial, title varchar(128),iscomplete boolean)
```

[create_table.sql](./tools/create_table.sql) 

#### アプリケーションが参照するDBアクセス用のシークレット登録

```
oc create secret generic secret-appsetting --from-literal=clientSecret='"DefaultConnection"="Host=postgresql;Port=5432;Database=todoapp;Username=postgres;Password=postgres;Trust Server Certificate=true;"'
```