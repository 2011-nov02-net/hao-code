-- add new columns
--alter table xxx add uuu as methods persist

-- view
-- active 
-- use view to select active ones
-- once created, can use it select statement, can update, insert, delelte, but some constraints cannot be used



-- with schemabinding
-- declare variable, select or set to assign variable
-- declare table, isnsert into
-- hace to run together, otherwise not stored and used

-- function, readonly
-- can declare, set values, and return values, everything in begin and end, need two goes top and bottom, as to connect signature and body
-- return table as well.
-- from view, tables, returned table-values from function


-- procedure can modify the db, not in select
-- being try, begin raiserror(not exceotion) end, begin catch end catch
-- print in black, not in red

-- declare a vairbale to store the date
-- execute procudure para 1, para2


-- trigger on table
-- instead of . after
-- inserted, deleted, modified rows, make changes on them


-- use commit and rollback for passed transaction, because of a failed tranaction
-- use savepoint to set a checkpoint 
-- something about 7. t sql  
-- rewatch if needed  230 tp 4
-- ACID, compromise isolaton because of performance

-- dirty read, if one sees uncommited data,  read_commited default, prevent dirty head
-- non repeatale read,  repeatable lock down
-- phantom read,  serializable
-- more isolation, more locks on parts, lower performance, more issues like deadlocks
-- last bits rewatch

