import React from 'react';
import Box from "@mui/joy/Box";
import {Divider, List, ListItem, Sheet} from "@mui/joy";
import Typography from "@mui/joy/Typography";
import ButtonLink from "@/features/home/sections/components/ButtonLink";
import AuctionListItem from "@/features/auctions/components/AuctionListItem";
const Bulk = () => {
    return (
        <section>
            <Box sx={{
                flex: '1',
                width: '100vw',
                minHeight: '100vh',
                padding: '2rem',
            }}>
                <List>
                    <AuctionListItem />
                    <Divider sx={{
                        maxWidth: '50rem'
                    }}/>
                    <AuctionListItem />
                </List>
            </Box>
        </section>
    );
};

export default Bulk;
