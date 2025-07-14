CREATE TABLE "Users" (
  "Id" SERIAL PRIMARY KEY,
  "Email" VARCHAR NOT NULL,
  "Password" VARCHAR NOT NULL,
  "Role" VARCHAR NOT NULL
);

INSERT INTO "Users" ("Email", "Password", "Role") VALUES
('admin@example.com', 'admin123', 'Admin'),
('user@example.com', 'user123', 'User');
